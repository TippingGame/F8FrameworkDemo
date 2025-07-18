# F8 接入HybridCLR

[![license](http://img.shields.io/badge/license-MIT-green.svg)](https://opensource.org/licenses/MIT) 
[![Unity Version](https://img.shields.io/badge/unity-2021|2022|2023|6000-blue)](https://unity.com) 
[![Platform](https://img.shields.io/badge/platform-Win%20%7C%20Android%20%7C%20iOS%20%7C%20Mac%20%7C%20Linux%20%7C%20WebGL-orange)]() 

## 导入插件（需要首先导入HybridCLR）
注意！HybridCLR：https://github.com/focus-creative-games/hybridclr_unity.git  
方式一：直接下载文件，放入Unity  
方式二：Unity->点击菜单栏->Window->Package Manager->点击+号->Add Package from git URL->输入：https://github.com/focus-creative-games/hybridclr_unity.git

### 视频教程：[【Unity框架】（21）接入HybridCLR](https://www.bilibili.com/video/BV1wpXCYaEAd)

## 简介（希望自己点击F8，就能开始制作游戏，不想多余的事）
接入HybridCLR热更新代码组件。
1. 使用这个[ 官方教程（快速上手） ](https://hybridclr.doc.code-philosophy.com/docs/beginner/quickstart)创建HotUpdate程序集后。  
2. 找到代码[ F8Helper.cs ](https://github.com/TippingGame/F8Framework/blob/main/Editor/F8Helper/F8Helper.cs)  
	* 解除注释状态，如下代码  
3. 补充元数据（可选项），具体看[ 官方教程（使用泛型） ](https://hybridclr.doc.code-philosophy.com/docs/beginner/generic)

```C#
// 补充元数据，不会热更新此处的dll，一般在{project}/HybridCLRData/AssembliesPostIl2CppStrip/{target}目录下
public static List<string> AOTDllList = new List<string>
{
    "mscorlib.dll",
    "System.dll",
    "System.Core.dll", // 如果使用了Linq，需要这个
    // "Newtonsoft.Json.dll", 
    // "protobuf-net.dll",
    "F8Framework.Core.dll", // 为了能使用框架中的泛型
};

[MenuItem("开发工具/3: 生成并复制热更新Dll-F8", false, 210)]
public static void GenerateCopyHotUpdateDll()
{
    // F8EditorPrefs.SetBool("compilationFinishedHotUpdateDll", false);
    // HybridCLR.Editor.Commands.PrebuildCommand.GenerateAll();
    //
    // string outpath = Application.dataPath + "/AssetBundles/Code/";
    //
    // FileTools.SafeClearDir(outpath);
    // FileTools.CheckDirAndCreateWhenNeeded(outpath);
    // foreach (var dll in HybridCLR.Editor.SettingsUtil.HotUpdateAssemblyNamesExcludePreserved) // 获取HybridCLR设置面板的dll名称
    // {
    //     var path =
    //         HybridCLR.Editor.SettingsUtil.GetHotUpdateDllsOutputDirByTarget(EditorUserBuildSettings
    //             .activeBuildTarget) + "/" + dll + ".dll";
    //     FileTools.SafeCopyFile(
    //         HybridCLR.Editor.SettingsUtil.GetHotUpdateDllsOutputDirByTarget(EditorUserBuildSettings.activeBuildTarget) + "/" + dll + ".dll",
    //         outpath + dll + ".bytes");
    //     LogF8.LogAsset("生成并复制热更新dll：" + dll);
    // }
    //
    // foreach (var aotDllName in F8Helper.AOTDllList)
    // {
    //     var mscorlibsouPath =
    //         HybridCLR.Editor.SettingsUtil.GetAssembliesPostIl2CppStripDir(EditorUserBuildSettings
    //             .activeBuildTarget) + "/" + aotDllName;
    //     
    //     FileTools.SafeCopyFile(
    //         mscorlibsouPath,
    //         outpath + aotDllName + "by.bytes");
    //     LogF8.LogAsset("生成并复制补充元数据dll：" + aotDllName);
    // }
    //
    // AssetDatabase.Refresh();
}
```
3. 代码已拆分程序集（注意：AOT代码不能引用热更代码）  
   * AOT程序集：（F8Framework.Core）、（注意：散落在工程中的其他代码也会当作AOT打包）  
   * 热更新程序集：（F8Framework.F8ExcelDataClass）、（F8Framework.Launcher）  
4. 将这两个热更新程序集拖进 HybridCLR 设置面板中  
![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/HybridCLR/ui_20241128235509.png)  
5. 注意：主工程不能直接引用热更新代码，这里通过反射来调用热更新代码。  
   * 在启动场景挂在一个加载dll脚本，先补充元数据（可选），加载热更新程序集
```C#
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
#else
            // Editor下无需加载，直接查找获得HotUpdate程序集
            Assembly hotUpdateAss = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "F8Framework.F8ExcelDataClass");
            Assembly hotUpdateAss2 = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "F8Framework.Launcher");
#endif
            Type type = hotUpdateAss2.GetType("F8Framework.Launcher.GameLauncher");
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
```
