using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using F8Framework.Core;
using HybridCLR;
using UnityEngine;

public class LoadDll : MonoBehaviour
{
    public IEnumerator Start()
    {
        ModuleCenter.Initialize(this);
        // 在这里可以启动热更新
        HotUpdateManager HotUpdate = ModuleCenter.CreateModule<HotUpdateManager>();
        DownloadManager DownloadManager = ModuleCenter.CreateModule<DownloadManager>();
        AssetManager AssetManager = ModuleCenter.CreateModule<AssetManager>();
        
        // 初始化本地版本
        HotUpdate.InitLocalVersion();

        // 初始化远程版本
        yield return HotUpdate.InitRemoteVersion();
            
        // 初始化资源版本
        yield return HotUpdate.InitAssetVersion();
            
        // 检查需要热更的资源，总大小
        Tuple<Dictionary<string, string>, long> result  = HotUpdate.CheckHotUpdate();
        var hotUpdateAssetUrl = result.Item1;
        var allSize = result.Item2;
        
        // 资源热更新
        HotUpdate.StartHotUpdate(hotUpdateAssetUrl, () =>
        {
            LogF8.Log("完成");
            // 先补充元数据（可选）
            List<string> aotDllList = new List<string>
            {
                "mscorlib.dll",
                "System.dll",
                "System.Core.dll", // 如果使用了Linq，需要这个
                // "Newtonsoft.Json.dll", 
                // "protobuf-net.dll",
                "F8Framework.Core.dll", // 为了能使用框架中的泛型
            };

            foreach (var aotDllName in aotDllList)
            {
                byte[] dllBytes = AssetManager.Instance.Load<TextAsset>(aotDllName + "by").bytes;
                LoadImageErrorCode err = HybridCLR.RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, HomologousImageMode.SuperSet);
                LogF8.Log($"LoadMetadataForAOTAssembly:{aotDllName}. ret:{err}");
            }
            
            // Editor环境下，HotUpdate.dll.bytes已经被自动加载，不需要加载，重复加载反而会出问题。
#if !UNITY_EDITOR
            TextAsset asset1 = AssetManager.Instance.Load<TextAsset>("F8Framework.F8ExcelDataClass");
            Assembly hotUpdateAss1 = Assembly.Load(asset1.bytes);
            TextAsset asset2 = AssetManager.Instance.Load<TextAsset>("F8Framework.Launcher");
            Assembly hotUpdateAss2 = Assembly.Load(asset2.bytes);
            TextAsset asset3 = AssetManager.Instance.Load<TextAsset>("DemoLauncher");
            Assembly hotUpdateAss3 = Assembly.Load(asset3.bytes);
            TextAsset asset4 = AssetManager.Instance.Load<TextAsset>("HotUpdate");
            Assembly hotUpdateAss4 = Assembly.Load(asset4.bytes);
#else
            // Editor下无需加载，直接查找获得HotUpdate程序集
            Assembly hotUpdateAss = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "F8Framework.F8ExcelDataClass");
            Assembly hotUpdateAss2 = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "F8Framework.Launcher");
            Assembly hotUpdateAss3 = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "DemoLauncher");
            Assembly hotUpdateAss4 = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "HotUpdate");
#endif
            Type type = hotUpdateAss3.GetType("DemoLauncher.DemoLauncher");
            // 添加组件
            gameObject.AddComponent(type);
        }, () =>
        {
            LogF8.Log("失败");
            
        }, progress =>
        {
            LogF8.Log("进度：" + progress);
        });
    }
}