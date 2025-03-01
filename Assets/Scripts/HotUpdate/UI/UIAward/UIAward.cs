using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using F8Framework.Core;
using F8Framework.Launcher;

public class UIAward : BaseView
{
    // Awake
    protected override void OnAwake()
    {
        Button_Mask_Button.onClick.AddListener(() =>
        {
            this.Close();
            FF8.UI.Open(DemoLauncher.DemoLauncher.UIID.UITip, new object[] { "已领取奖励" });
        });
        Button_Close_Button.onClick.AddListener(() =>
        {
            this.Close();
            FF8.UI.Open(DemoLauncher.DemoLauncher.UIID.UITip, new object[] { "已领取奖励" });
        });
        Button_Get_Button.onClick.AddListener(() =>
        {
            this.Close();
            FF8.UI.Open(DemoLauncher.DemoLauncher.UIID.UITip, new object[] { "已领取奖励" });
        });
    }
    
    // 参数传入
    protected override void OnAdded(int uiId, object[] args = null)
    {
        FF8.Input.AddButtonPerformed(InputButtonType.EscClick, Performed);
    }

    private void Performed(string obj)
    {
        this.Close();
    }

    // Start
    protected override void OnStart()
    {
        
    }
    
    protected override void OnViewTweenInit()
    {
        go_Bg_go.SetLocalScale(Vector3.one * 0.7f);
    }
    
    // 自定义打开界面动画
    protected override void OnPlayViewTween()
    {
        go_Bg_go.ScaleTween(Vector3.one, 0.5f).SetEase(Ease.Linear).SetOnComplete(OnViewOpen);
    }
    
    // 打开界面动画完成后
    protected override void OnViewOpen()
    {
        
    }
    
    // 删除之前
    protected override void OnBeforeRemove()
    {
        FF8.Input.RemoveButtonPerformed(InputButtonType.EscClick, Performed);
    }
    
    // 删除
    protected override void OnRemoved()
    {
        
    }
    
    // 自动获取组件（自动生成，不能删除）
    [SerializeField] private Button Button_Mask_Button;
    [SerializeField] private GameObject go_Bg_go;
    [SerializeField] private Button Button_Close_Button;
    [SerializeField] private ScrollRect ScrollRect_ScrollRect;
    [SerializeField] private Button Button_Get_Button;
    [SerializeField] private Text TextLegacy_TextLegacy;
    [SerializeField] private TMPro.TMP_Text TextTMP_TextTMP;
    [SerializeField] private TMPro.TMP_Text TextTMP_TextTMP_2;
    [SerializeField] private TMPro.TMP_Text TextTMP_TextTMP_3;
    [SerializeField] private TMPro.TMP_Text TextTMP_TextTMP_4;
    [SerializeField] private TMPro.TMP_Text TextTMP_TextTMP_5;

#if UNITY_EDITOR
    protected override void SetComponents()
    {
        Button_Mask_Button = transform.Find("Button_Mask").GetComponent<Button>();
        go_Bg_go = transform.Find("go_Bg").gameObject;
        Button_Close_Button = transform.Find("go_Bg/Button_Close").GetComponent<Button>();
        ScrollRect_ScrollRect = transform.Find("go_Bg/ScrollRect").GetComponent<ScrollRect>();
        Button_Get_Button = transform.Find("go_Bg/Button_Get").GetComponent<Button>();
        TextLegacy_TextLegacy = transform.Find("go_Bg/Button_Get/Text (Legacy)").GetComponent<Text>();
        TextTMP_TextTMP = transform.Find("go_Bg/ScrollRect/Veiwport/Content/Item/Text (TMP)").GetComponent<TMPro.TMP_Text>();
        TextTMP_TextTMP_2 = transform.Find("go_Bg/ScrollRect/Veiwport/Content/Item/Text (TMP)").GetComponent<TMPro.TMP_Text>();
        TextTMP_TextTMP_3 = transform.Find("go_Bg/ScrollRect/Veiwport/Content/Item/Text (TMP)").GetComponent<TMPro.TMP_Text>();
        TextTMP_TextTMP_4 = transform.Find("go_Bg/ScrollRect/Veiwport/Content/Item/Text (TMP)").GetComponent<TMPro.TMP_Text>();
        TextTMP_TextTMP_5 = transform.Find("go_Bg/ScrollRect/Veiwport/Content/Item/Text (TMP)").GetComponent<TMPro.TMP_Text>();
    }
#endif
    // 自动获取组件（自动生成，不能删除）
}