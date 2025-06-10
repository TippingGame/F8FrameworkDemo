using System.Collections;
using System.Collections.Generic;
using F8Framework.Core;
using F8Framework.Launcher;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class DemoInitState : ProcedureNode
{
    public enum UIID
    {
        // UI枚举
        Empty = 0,
        UISelectRole = 1, // 选择角色
        UIGameView = 2, // 游戏界面
        UIAward = 3, // 奖励
        UITip = 4, // 提示
    }
        
    private Dictionary<UIID, UIConfig> _configs = new Dictionary<UIID, UIConfig>
    {
        { UIID.UISelectRole, new UIConfig(LayerType.UI, "UISelectRole") },
        { UIID.UIGameView, new UIConfig(LayerType.UI, "UIGameView") },
        { UIID.UIAward, new UIConfig(LayerType.Dialog, "UIAward") },
        { UIID.UITip, new UIConfig(LayerType.Notify, "UITip") },
    };
    public override void OnInit(ProcedureProcessor processor)
    {
            
    }
        
    public override void OnEnter(ProcedureProcessor processor)
    {
        Util.Unity.StartCoroutine(LoadAll());
    }

    IEnumerator LoadAll()
    {
        foreach (var item in FF8.Config.LoadAllAsync()) // 异步加载全部配置
        {
            yield return item;
        }

#if UNITY_EDITOR
        ReadExcel.Instance.LoadAllExcelData();
#endif
        
        LogF8.Log(FF8.Config.GetroleByID(1).name);
            
        yield return FF8.Asset.LoadAsync("IsometricSpriteAtlas");
        
        // 加载文件夹内资产
        FF8.Asset.LoadDirAsync("Role_Textures", () =>
        {
            // 初始化
            FF8.UI.Initialize(_configs);
            
            FF8.UI.SetCanvasScaler(null, CanvasScaler.ScaleMode.ScaleWithScreenSize, referenceResolution: new Vector2(1920, 1080),
                CanvasScaler.ScreenMatchMode.MatchWidthOrHeight, matchWidthOrHeight: 0f, referencePixelsPerUnit: 100f);
            
            FF8.UI.OpenAsync(DemoInitState.UIID.UISelectRole);
        });

        FF8.Asset.LoadAsync<AudioMixer>("F8AudioMixer", mixer => FF8.Audio.SetAudioMixer(mixer));
        
        FF8.Audio.PlayMusic("02b Town Theme", null, true);
    }

    public override void OnExit(ProcedureProcessor processor)
    {
            
    }
    
    public override void OnUpdate(ProcedureProcessor processor)
    {
            
    }
        
    public override void OnDestroy(ProcedureProcessor processor)
    {
            
    }
}
