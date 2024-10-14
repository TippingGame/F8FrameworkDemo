using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using F8Framework.Core;

public class GameDataModule : StaticModule
{
    public static GameDataModule Instance => GetInstance<GameDataModule>();

    public int RoleId = 0;
    
    // 消息的定义，枚举
    public enum MessageEvent
    {
        // 框架事件，10000起步
        Empty = 1,
        SubHp = 10, // 扣血
    }
    
    // 初始化Center
    protected override void Init()
    {
        
    }

    // 进入游戏
    public override void OnEnterGame()
    {
        
    }

    // 退出游戏
    public override void OnQuitGame()
    {
        RoleId = 0;
    }
}