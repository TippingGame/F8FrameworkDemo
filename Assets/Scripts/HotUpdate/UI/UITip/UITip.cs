using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using F8Framework.Core;

public class UITip : BaseView
{
    // Awake
    protected override void OnAwake()
    {
        
    }
    
    // 参数传入
    protected override void OnAdded(int uiId, object[] args = null)
    {
        TextLegacy_TextLegacy.text = args[0].ToString();
    }
    
    // Start
    protected override void OnStart()
    {
        
    }
    
    protected override void OnViewTweenInit()
    {
        go_MessageDefault_go.transform.localPosition = new Vector3(0,-106,0);
    }
    
    // 自定义打开界面动画
    protected override void OnPlayViewTween()
    {
        go_MessageDefault_go.LocalMove(new Vector3(0,300,0), 2f).SetEase(Ease.Linear).SetOnComplete(OnViewOpen);
    }
    
    // 打开界面动画完成后
    protected override void OnViewOpen()
    {
        this.Close();
    }
    
    // 删除之前
    protected override void OnBeforeRemove()
    {
        
    }
    
    // 删除
    protected override void OnRemoved()
    {
        
    }
    
    // 自动获取组件（自动生成，不能删除）
    [SerializeField] private GameObject go_MessageDefault_go;
    [SerializeField] private Text TextLegacy_TextLegacy;

#if UNITY_EDITOR
    protected override void SetComponents()
    {
        go_MessageDefault_go = transform.Find("go_MessageDefault").gameObject;
        TextLegacy_TextLegacy = transform.Find("go_MessageDefault/Text (Legacy)").GetComponent<Text>();
    }
#endif
    // 自动获取组件（自动生成，不能删除）
}