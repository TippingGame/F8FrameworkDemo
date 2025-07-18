# F8 AudioManager

[![license](http://img.shields.io/badge/license-MIT-green.svg)](https://opensource.org/licenses/MIT) 
[![Unity Version](https://img.shields.io/badge/unity-2021|2022|2023|6000-blue)](https://unity.com) 
[![Platform](https://img.shields.io/badge/platform-Win%20%7C%20Android%20%7C%20iOS%20%7C%20Mac%20%7C%20Linux%20%7C%20WebGL-orange)]() 

## 简介（希望自己点击F8，就能开始制作游戏，不想多余的事）
Unity F8 AudioManager组件，播放，暂停，停止，进度控制，音量控制/保存，全局暂停/恢复。可选AudioMixer  
Audio分为三大类：  
1.背景音乐  
2.人声  
3.特效声  

## 导入插件（需要首先导入核心）
注意！内置在->F8Framework核心：https://github.com/TippingGame/F8Framework.git  
方式一：直接下载文件，放入Unity  
方式二：Unity->点击菜单栏->Window->Package Manager->点击+号->Add Package from git URL->输入：https://github.com/TippingGame/F8Framework.git  

### 视频教程：[【Unity框架】（5）声音管理](https://www.bilibili.com/video/BV1x1421k7UL)

### 代码使用方法
```C#
void Start()
{
    /*----------背景音乐----------*/
    // assetName资产名
    // callback播放完成回调
    // loop是否循环
    // priority优先级，高的覆盖低的
    // fadeDuration淡入持续时间
    FF8.Audio.PlayMusic("assetName", CallBack, loop: true, priority: 1, fadeDuration: 3f); // 背景音乐
    float progress = FF8.Audio.ProgressMusic; // 获取进度
    FF8.Audio.SetProgressMusic = 0.5f; // 设置进度
    FF8.Audio.VolumeMusic = 0.5f; // 设置音量，自动保存至PlayerPrefs
    FF8.Audio.SwitchMusic = false; // 设置开关，自动保存至PlayerPrefs
    FF8.Audio.SetMusicComplete(CallBack); // 设置完成回调
    
    /*----------人声----------*/
    FF8.Audio.PlayVoice("assetName", CallBack, true, 1, 3f); // 角色语音
    float progressVoice = FF8.Audio.ProgressVoice; // 获取进度
    FF8.Audio.SetProgressVoice = 0.5f; // 设置进度
    FF8.Audio.VolumeVoice = 0.5f; // 设置音量，自动保存至PlayerPrefs
    FF8.Audio.SwitchVoice = false; // 设置开关，自动保存至PlayerPrefs
    FF8.Audio.SetVoiceComplete(CallBack); // 设置完成回调
    
    /*----------特效声----------*/
    FF8.Audio.PlayUISound("assetName", CallBack, true, 1, 3f); // ui音效
    FF8.Audio.PlayBtnClick("assetName", CallBack, false, 2, 3f); // 按钮音效
    FF8.Audio.PlayAudioEffect("assetName", CallBack, false, 2, 3f); // 音效特效
    FF8.Audio.VolumeAudioEffect = 0.5f; // 设置音量，自动保存至PlayerPrefs
    FF8.Audio.SwitchAudioEffect = false; // 设置开关，自动保存至PlayerPrefs
    FF8.Audio.SetUISoundComplete(CallBack); // 设置完成回调
    FF8.Audio.SetBtnClickComplete(CallBack); // 设置完成回调
    FF8.Audio.SetAudioEffectComplete(CallBack); // 设置完成回调
    
    /*----------一次性3D音效----------*/
    // assetName资产名
    // isRandom是否随机音量音高
    // audioPosition音频播放位置
    // volume音量
    // spatialBlend2d到3d的比例
    // maxNum最大同时播放个数
    // callback播放完成回调
    FF8.Audio.PlayAudioEffect3D("assetName", isRandom: true, transform.position, volume: 1f, spatialBlend: 1f, maxNum: 5, CallBack);
    FF8.Audio.VolumeAudioEffect = 0.5f; // 设置音量，自动保存至PlayerPrefs
    FF8.Audio.SwitchAudioEffect = false; // 设置开关，自动保存至PlayerPrefs
    
    /*----------其他功能----------*/
    
    // 可选，设置混音组F8AudioMixer，需手动放到可加载目录
    FF8.Audio.SetAudioMixer(FF8.Asset.Load<AudioMixer>("F8AudioMixer"));

    /*----------全局控制----------*/
    FF8.Audio.PauseAll(); // 暂停所有，不包括AudioEffect
    FF8.Audio.ResumeAll(); // 恢复所有，不包括AudioEffect
    FF8.Audio.StopAll(); // 停止所有，不包括AudioEffect

    FF8.Audio.UnloadAll(true); // 卸载所有音频和音效。（true:完全卸载，包括正在使用的）

    /*----------单独控制----------*/
    FF8.Audio.AudioMusic.Pause();
    FF8.Audio.AudioMusicVoice.Resume();
    FF8.Audio.AudioMusicBtnClick.Stop();
    FF8.Audio.AudioMusicUISound.UnloadAll();
    FF8.Audio.AudioMusicAudioEffect.UnloadAll(true);
    
    void CallBack()
    {

    }
}
```


