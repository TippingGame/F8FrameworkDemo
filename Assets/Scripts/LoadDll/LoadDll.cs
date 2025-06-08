// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using System.Reflection;
// using F8Framework.Core;
// using HybridCLR;
// using UnityEngine;
//
// public class LoadDll : MonoBehaviour
// {
//     public IEnumerator Start()
//     {
//         ModuleCenter.Initialize(this);
//         // 在这里可以启动热更新
//         HotUpdateManager HotUpdate = ModuleCenter.CreateModule<HotUpdateManager>();
//         DownloadManager DownloadManager = ModuleCenter.CreateModule<DownloadManager>();
//         AssetManager AssetManager = ModuleCenter.CreateModule<AssetManager>();
//         
//         // 初始化本地版本
//         HotUpdate.InitLocalVersion();
//
//         // 初始化远程版本
//         yield return HotUpdate.InitRemoteVersion();
//             
//         // 初始化资源版本
//         yield return HotUpdate.InitAssetVersion();
//             
//         // 检查需要热更的资源，总大小
//         Tuple<Dictionary<string, string>, long> result  = HotUpdate.CheckHotUpdate();
//         var hotUpdateAssetUrl = result.Item1;
//         var allSize = result.Item2;
//         
//         // 资源热更新
//         HotUpdate.StartHotUpdate(hotUpdateAssetUrl, () =>
//         {
//             LogF8.Log("完成");
//             
//             StartCoroutine(LoadAssembliesCoroutine());
//            
//         }, () =>
//         {
//             LogF8.Log("失败");
//             
//         }, progress =>
//         {
//             LogF8.Log("进度：" + progress);
//         });
//     }
//
//     public IEnumerator LoadAssembliesCoroutine()
//     {
//  // 先补充元数据（可选）
//             List<string> aotDllList = new List<string>
//             {
//                 "mscorlib.dll",
//                 "System.dll",
//                 "System.Core.dll", // 如果使用了Linq，需要这个
//                 // "Newtonsoft.Json.dll", 
//                 // "protobuf-net.dll",
//                 "F8Framework.Core.dll", // 为了能使用框架中的泛型
//             };
//
//             foreach (var aotDllName in aotDllList)
//             {
//                 BaseLoader load = AssetManager.Instance.LoadAsync<TextAsset>(aotDllName + "by");
//                 yield return load;
//                 byte[] dllBytes = load.GetAssetObject<TextAsset>().bytes;
//                 LoadImageErrorCode err = HybridCLR.RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, HomologousImageMode.SuperSet);
//                 LogF8.Log($"LoadMetadataForAOTAssembly:{aotDllName}. ret:{err}");
//             }
//             
//             // Editor环境下，HotUpdate.dll.bytes已经被自动加载，不需要加载，重复加载反而会出问题。
// #if !UNITY_EDITOR
//             BaseLoader load1 = AssetManager.Instance.LoadAsync<TextAsset>("F8Framework.F8ExcelDataClass");
//             yield return load1;
//             TextAsset asset1 = load1.GetAssetObject<TextAsset>();
//             Assembly hotUpdateAss1 = Assembly.Load(asset1.bytes);
//             BaseLoader load2 = AssetManager.Instance.LoadAsync<TextAsset>("F8Framework.Launcher");
//             yield return load2;
//             TextAsset asset2 = load2.GetAssetObject<TextAsset>();
//             Assembly hotUpdateAss2 = Assembly.Load(asset2.bytes);
//             BaseLoader load3 = AssetManager.Instance.LoadAsync<TextAsset>("DemoLauncher");
//             yield return load3;
//             TextAsset asset3 = load3.GetAssetObject<TextAsset>();
//             Assembly hotUpdateAss3 = Assembly.Load(asset3.bytes);
//             BaseLoader load4 = AssetManager.Instance.LoadAsync<TextAsset>("HotUpdate");
//             yield return load4;
//             TextAsset asset4 = load4.GetAssetObject<TextAsset>();
//             Assembly hotUpdateAss4 = Assembly.Load(asset4.bytes);
// #else
//             // Editor下无需加载，直接查找获得HotUpdate程序集
//             Assembly hotUpdateAss = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "F8Framework.F8ExcelDataClass");
//             Assembly hotUpdateAss2 = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "F8Framework.Launcher");
//             Assembly hotUpdateAss3 = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "DemoLauncher");
//             Assembly hotUpdateAss4 = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "HotUpdate");
// #endif
//             Type type = hotUpdateAss3.GetType("DemoLauncher.DemoLauncher");
//             
//             // 添加组件
//             gameObject.AddComponent(type);
//     }
//     
//     void Update()
//     {
//         // 更新模块
//         ModuleCenter.Update();
//     }
//
//     void LateUpdate()
//     {
//         // 更新模块
//         ModuleCenter.LateUpdate();
//     }
//
//     void FixedUpdate()
//     {
//         // 更新模块
//         ModuleCenter.FixedUpdate();
//     }
// }