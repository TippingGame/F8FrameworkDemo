using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using F8Framework.Core;
using F8Framework.Launcher;

public class UIGameView : BaseView
{
    private List<Transform> hps = new List<Transform>();

    private int hp = 5;
    // Awake
    protected override void OnAwake()
    {
        FF8.Message.AddEventListener(GameDataModule.MessageEvent.SubHp, SubHp, this);
    }

    private void SubHp()
    {
        hp -= 1;
        for (int i = 0; i < hps.Count; i++)
        {
            hps[i].gameObject.SetActive(hp > i);
        }
    }

    private int timeid = 0;
    // 参数传入
    protected override void OnAdded(int uiId, object[] args = null)
    {
        hps.Add(tf_hp_tf);
        for (int i = 1; i < 5; i++)
        {
            hps.Add(Instantiate(tf_hp_tf, tf_group_tf));
        }

        int count = 0;
        timeid = FF8.Timer.AddTimer(this, 1f, 0f, -1, () =>
        {
            count += 1;
            TimeSpan timeSpan = TimeSpan.FromSeconds(count);
            TextLegacy_TextLegacy.text = timeSpan.Minutes.ToString("D2") + ":" + timeSpan.Seconds.ToString("D2");
        }, () =>
        {
            
        });
    }
    
    // Start
    protected override void OnStart()
    {
        
    }
    
    protected override void OnViewTweenInit()
    {
        //transform.localScale = Vector3.one * 0.7f;
    }
    
    // 自定义打开界面动画
    protected override void OnPlayViewTween()
    {
        //transform.ScaleTween(Vector3.one, 0.1f).SetEase(Ease.Linear).SetOnComplete(OnViewOpen);
    }
    
    // 打开界面动画完成后
    protected override void OnViewOpen()
    {
        
    }
    
    // 删除之前
    protected override void OnBeforeRemove()
    {
        FF8.Timer.RemoveTimer(timeid);
    }
    
    // 删除
    protected override void OnRemoved()
    {
        FF8.Message.RemoveEventListener(GameDataModule.MessageEvent.SubHp, SubHp, this);
    }
    
    // 自动获取组件（自动生成，不能删除）
    [SerializeField] private Transform tf_group_tf;
    [SerializeField] private Text TextLegacy_TextLegacy;
    [SerializeField] private Transform tf_hp_tf;

#if UNITY_EDITOR
    protected override void SetComponents()
    {
        tf_group_tf = transform.Find("tf_group").GetComponent<Transform>();
        TextLegacy_TextLegacy = transform.Find("Text (Legacy)").GetComponent<Text>();
        tf_hp_tf = transform.Find("tf_group/tf_hp").GetComponent<Transform>();
    }
#endif
    // 自动获取组件（自动生成，不能删除）
}