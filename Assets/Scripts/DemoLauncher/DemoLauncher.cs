using System;
using System.Collections;
using System.Collections.Generic;
using F8Framework.Core;
using F8Framework.F8ExcelDataClass;
using F8Framework.Launcher;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace DemoLauncher
{
    public class DemoLauncher : MonoBehaviour
    {
        IEnumerator Start()
        {
            // 初始化模块中心
            ModuleCenter.Initialize(this);

            // 初始化版本
            FF8.HotUpdate = ModuleCenter.CreateModule<HotUpdateManager>();

            // 按顺序创建模块，可按需添加
            FF8.Message = ModuleCenter.CreateModule<MessageManager>();
            FF8.Input = ModuleCenter.CreateModule<InputManager>(new DefaultInputHelper());
            FF8.Storage = ModuleCenter.CreateModule<StorageManager>();
            FF8.Timer = ModuleCenter.CreateModule<TimerManager>();
            FF8.Procedure = ModuleCenter.CreateModule<ProcedureManager>();
            FF8.Network = ModuleCenter.CreateModule<NetworkManager>();
            FF8.FSM = ModuleCenter.CreateModule<FSMManager>();
            FF8.GameObjectPool = ModuleCenter.CreateModule<GameObjectPool>();
            FF8.Asset = ModuleCenter.CreateModule<AssetManager>();
            yield return AssetBundleManager.Instance.LoadAssetBundleManifest(); // 加载 AssetBundleManifest，必须在 AssetManager 模块下面
            FF8.Config = ModuleCenter.CreateModule<F8DataManager>();
            FF8.Audio = ModuleCenter.CreateModule<AudioManager>();
            FF8.Tween = ModuleCenter.CreateModule<Tween>();
            FF8.UI = ModuleCenter.CreateModule<UIManager>();
            yield return F8DataManager.Instance.LoadLocalizedStringsIEnumerator(); // 加载 LocalizedStrings 配置表，必须在 Localization 模块上面
            FF8.Local = ModuleCenter.CreateModule<Localization>();
            FF8.SDK = ModuleCenter.CreateModule<SDKManager>();
            FF8.Download = ModuleCenter.CreateModule<DownloadManager>();
            FF8.LogWriter = ModuleCenter.CreateModule<F8LogWriter>();
            
            yield return new WaitForEndOfFrame();

            // // 初始化本地版本
            // FF8.HotUpdate.InitLocalVersion();
            //
            // // 初始化远程版本
            // yield return FF8.HotUpdate.InitRemoteVersion();
            //
            // // 初始化资源版本
            // yield return FF8.HotUpdate.InitAssetVersion();
            //
            // // 检查需要热更的资源，总大小
            // Tuple<Dictionary<string, string>, long> result  = FF8.HotUpdate.CheckHotUpdate();
            // var hotUpdateAssetUrl = result.Item1;
            // var allSize = result.Item2;
            //
            // LogF8.Log(hotUpdateAssetUrl.Count + "个资源需要热更，总大小：" + allSize);
            // // 资源热更新
            // FF8.HotUpdate.StartHotUpdate(hotUpdateAssetUrl, () =>
            // {
            //     LogF8.Log("完成");
            // }, () =>
            // {
            //     LogF8.Log("失败");
            // }, progress =>
            // {
            //     LogF8.Log("进度：" + progress);
            // });
            //
            // // 检查未加载的分包
            // List<string> subPackage = FF8.HotUpdate.CheckPackageUpdate(GameConfig.LocalGameVersion.SubPackage);
            //
            // // 分包加载
            // FF8.HotUpdate.StartPackageUpdate(subPackage, () =>
            // {
            //     LogF8.Log("完成");
            // }, () =>
            // {
            //     LogF8.Log("失败");
            // }, progress =>
            // {
            //     LogF8.Log("进度：" + progress);
            // });
            
            StartGame();
            yield break;
        }

        // 开始游戏
        public void StartGame()
        {
            LogF8.LogVersion("更新代码成功！WebGL!");
            
            FF8.Procedure.RunProcedureNode<DemoInitState>();
        }
        
        void Update()
        {
            // 更新模块
            ModuleCenter.Update();
        }

        void LateUpdate()
        {
            // 更新模块
            ModuleCenter.LateUpdate();
        }

        void FixedUpdate()
        {
            // 更新模块
            ModuleCenter.FixedUpdate();
        }
    }
}
