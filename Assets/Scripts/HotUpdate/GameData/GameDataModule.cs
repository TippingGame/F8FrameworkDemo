using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using F8Framework.Core;

public class GameDataModule : StaticModule
{
    public static GameDataModule Instance => GetInstance<GameDataModule>();

    public int RoleId = 0;
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