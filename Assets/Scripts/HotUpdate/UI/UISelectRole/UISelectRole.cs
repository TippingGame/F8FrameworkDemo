using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using F8Framework.Core;
using F8Framework.Launcher;

public class UISelectRole : BaseView
{
    // Awake
    protected override void OnAwake()
    {
        
    }
    
    // 参数传入
    protected override void OnAdded(int uiId, object[] args = null)
    {
        
    }
    
    // Start
    protected override void OnStart()
    {
        foreach (var data in FF8.Config.Getrole())
        {
            Transform tr = Instantiate(Transform_Transform, Transform_Layout_Transform);
            tr.GetComponent<RoleItem>().Refresh(data.Key);
        }
        
        Transform_Transform.gameObject.SetActive(false);
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
    
    // 删除之前
    protected override void OnBeforeRemove()
    {
       
    }
    
    // 删除
    protected override void OnRemoved()
    {
        
    }
    
    // 自动获取组件（自动生成，不能删除）
    [SerializeField] private Transform Transform_Layout_Transform;
    [SerializeField] private Transform Transform_Transform;
    [SerializeField] private Button ButtonLegacy_Button;
    [SerializeField] private Text TextLegacy_TextLegacy;

#if UNITY_EDITOR
    protected override void SetComponents()
    {
        Transform_Layout_Transform = transform.Find("Transform_Layout").GetComponent<Transform>();
        Transform_Transform = transform.Find("Transform_Layout/Transform").GetComponent<Transform>();
        ButtonLegacy_Button = transform.Find("Transform_Layout/Transform/Button (Legacy)").GetComponent<Button>();
        TextLegacy_TextLegacy = transform.Find("Transform_Layout/Transform/Button (Legacy)/Text (Legacy)").GetComponent<Text>();
    }
#endif
    // 自动获取组件（自动生成，不能删除）
}