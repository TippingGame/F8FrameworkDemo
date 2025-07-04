using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using F8Framework.Core;
using F8Framework.Launcher;
using UnityEngine.SceneManagement;

public class RoleItem : BaseItem
{
    private int _index = -1;
    // 预留给刷新Item使用
    public void Refresh(int index)
    {
        _index = index;
        
        FF8.Asset.LoadAsync<Sprite>("PackForest_" + _index, sprite =>
        {
            ButtonLegacy_Button.transform.GetComponent<Image>().sprite = sprite;
            ButtonLegacy_Button.transform.GetComponent<Image>().SetNativeSize();
        });
        
        TextLegacy_TextLegacy.text = FF8.Config.GetroleByID(index).name;
    }
    
    // OnEnable
    private void OnEnable()
    {
        
    }
    
    // Awake
    protected override void OnAwake()
    {
        ButtonLegacy_Button.onClick.AddListener(() =>
        {
            FF8.Audio.PlayUISound("Electronic high shot");
            FF8.UI.Close(1, true);
            GameDataModule.Instance.RoleId = _index;
            FF8.Procedure.RunProcedureNode<DemoGameState>();
        });
    }
    
    // Start
    protected override void OnStart()
    {
        
    }
    
    protected override void OnViewTweenInit()
    {
        transform.localScale = Vector3.one * 0.7f;
    }
    
    // 自定义打开界面动画
    protected override void OnPlayViewTween()
    {
        transform.ScaleTween(Vector3.one, 0.1f).SetEase(Ease.Linear).SetOnComplete(OnViewOpen);
    }
    
    // 打开界面动画完成后
    protected override void OnViewOpen()
    {
        
    }
    
    // OnDisable
    private void OnDisable()
    {
        if (_index == -1)
        {
            return;
        }
        FF8.Asset.Unload("PackForest_" + _index, true);
    }
    
    // 自动获取组件（自动生成，不能删除）
    [SerializeField] private Button ButtonLegacy_Button;
    [SerializeField] private Text TextLegacy_TextLegacy;

#if UNITY_EDITOR
    protected override void SetComponents()
    {
        ButtonLegacy_Button = transform.Find("Button (Legacy)").GetComponent<Button>();
        TextLegacy_TextLegacy = transform.Find("Button (Legacy)/Text (Legacy)").GetComponent<Text>();
    }
#endif
    // 自动获取组件（自动生成，不能删除）
}