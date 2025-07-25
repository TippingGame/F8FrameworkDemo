# F8 SDKManager

[![license](http://img.shields.io/badge/license-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Unity Version](https://img.shields.io/badge/unity-2021|2022|2023|6000-blue)](https://unity.com)
[![Platform](https://img.shields.io/badge/platform-Win%20%7C%20Android%20%7C%20iOS%20%7C%20Mac%20%7C%20Linux%20%7C%20WebGL-orange)]()

## 简介（希望自己点击F8，就能开始制作游戏，不想多余的事）
Unity F8 SDKManager组件，与原生平台交互，接入多个平台或者渠道SDK，登录/退出/切换/支付/视频广告/退出游戏/Toast

## 导入插件（需要首先导入核心）
注意！内置在->F8Framework核心：https://github.com/TippingGame/F8Framework.git  
方式一：直接下载文件，放入Unity  
方式二：Unity->点击菜单栏->Window->Package Manager->点击+号->Add Package from git URL->输入：https://github.com/TippingGame/F8Framework.git

### 视频教程：[【Unity框架】（18）SDK接入管理](https://www.bilibili.com/video/BV1PhR8YiEBa)

### 代码使用方法
```C#
    // 启动SDK，平台id，渠道id
    FF8.SDK.SDKStart("1", "1");
    
    // 登录
    FF8.SDK.SDKLogin();
    
    // 登出
    FF8.SDK.SDKLogout();
    
    // 切换账号
    FF8.SDK.SDKSwitchAccount();
    
    // 加载视频广告
    FF8.SDK.SDKLoadVideoAd("1", "1");
    
    // 播放视频广告
    FF8.SDK.SDKShowVideoAd("1", "1");
    
    // 支付
    FF8.SDK.SDKPay("serverNum", "serverName", "playerId", "playerName", "amount", "extra", "orderId",
        "productName", "productContent", "playerLevel", "sign", "guid");
    
    // 更新用户信息
    FF8.SDK.SDKUpdateRole("scenes", "serverId", "serverName", "roleId", "roleName", "roleLeve", "roleCTime", "rolePower", "guid");
    
    // SDK退出游戏
    FF8.SDK.SDKExitGame();
    
    // 原生提示
    FF8.SDK.SDKToast("Native Toast");
```

## 安卓工程使用方法
### 如需要接入隐私政策，或接入安卓端SDK与安卓端交互，可按照下方教程手动操作

* （注意：首先确定你的unity使用什么Gradle版本）[unity文档Gradle版本](https://docs.unity3d.com/2021.3/Documentation/Manual/android-gradle-overview.html)
* 框架只适配下列版本，unity的Gradle版本也可以在安装目录查看，如：（`C:\Program Files\Unity\Hub\Editor\2021.3.15f1\Editor\Data\PlaybackEngines\AndroidPlayer\Tools\gradle\lib`）
* unity2021各个版本（2021.2 / 2021.1 starting from 2021.1.16f1：Gradle6.1.1）  
  ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_20241120134318.png)  
* unity2022各个版本（2022.1：Gradle6.1.1）  
  ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_20241120134325.png)  
* unity2023各个版本（2023.1：Gradle7.6）  
  ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_20241121004145.png)  
* unity6000各个版本（怀疑8.7.2写错，目前8.11最高支持8.4.2）  
  ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_20241120134329_2.png)  
------------------------------
* 根据你版本，选择正确的目录，复制下面这两个文件到工程 `Assets/Plugins/Android` 目录  
* 给文件 [AndroidManifest.xml](https://github.com/TippingGame/F8Framework/blob/main/Runtime/SDKManager/Plugins_Android/AndroidPJ2021/Gradle6.1.1/AndroidManifest) 添加上后缀`.xml`  
* 给文件 [UnityAndroidDemo-release.aar](https://github.com/TippingGame/F8Framework/blob/main/Runtime/SDKManager/Plugins_Android/AndroidPJ2021/Gradle6.1.1/UnityAndroidDemo-release) 添加上后缀`.aar`  
  ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_20241120213148.png)  
  ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_20241120213210.png)  
------------------------------
* 注意：每个unity版本略有差异，更换unity版本后请手动删除这两个文件
------------------------------
* （可选）使用安卓工程打包aar [UnityAndroidDemo2021.3.15f1.zip](https://github.com/TippingGame/F8Framework/blob/main/Runtime/SDKManager/Plugins_Android/AndroidPJ2021/UnityAndroidDemo2021.3.15f1.zip)，用作导出 [UnityAndroidDemo-release.aar](https://github.com/TippingGame/F8Framework/blob/main/Runtime/SDKManager/Plugins_Android/AndroidPJ2021/Gradle6.1.1/UnityAndroidDemo-release) 和 [AndroidManifest.xml](https://github.com/TippingGame/F8Framework/blob/main/Runtime/SDKManager/Plugins_Android/AndroidPJ2021/Gradle6.1.1/AndroidManifest)
  1. 下载 [Android Studio](https://developer.android.google.cn/studio/archive/) （网页右上角语言改为英文）
  2. 选择版本：
     * Unity 2022 / 2023：`android-studio-2022.2.1.20-windows`
     * Unity 2023 / 6000：`2023.3.1.20-windows`
  3. 解压工程打开后，在 **Settings -> Build -> Build Tool -> Gradle -> Gradle JDK**，修改 JDK 为unity安装路径自带的（如：`C:\Program Files\Unity\Hub\Editor\6000.1.5f1\Editor\Data\PlaybackEngines\AndroidPlayer\OpenJDK`）
  4. 在 **Project Structure -> Project / SDK Location**，修改 Gradle 版本，修改 SDK 为unity安装路径自带的（如：`C:\Program Files\Unity\Hub\Editor\6000.1.5f1\Editor\Data\PlaybackEngines\AndroidPlayer\SDK`）
  5. 上方菜单栏 **Build -> Rebuild Project** 导出后会生成aar文件
  6. 使用可以读取zip的压缩软件，删除aar里 `libs/classes.jar` 文件
  7. 再打开根目录的 `classes.jar` ，删除里面的 `UnityPlayerActivity.java` 文件（unity2023 / 6000不需要此步骤）
------------------------------

* 提供四个unity版本的安卓工程
  1. unity2021.3.15f1：[UnityAndroidDemo2021.3.15f1.zip](https://github.com/TippingGame/F8Framework/blob/main/Runtime/SDKManager/Plugins_Android/AndroidPJ2021/UnityAndroidDemo2021.3.15f1.zip)  
  2. unity2022.3.52f1：[UnityAndroidDemo2022.3.52f1.zip](https://github.com/TippingGame/F8Framework/blob/main/Runtime/SDKManager/Plugins_Android/AndroidPJ2022/UnityAndroidDemo2022.3.52f1.zip)  
  3. unity2023.2.20f1（2023已被unity弃用）：[UnityAndroidDemo2023.2.20f1.zip](https://github.com/TippingGame/F8Framework/blob/main/Runtime/SDKManager/Plugins_Android/AndroidPJ2023/UnityAndroidDemo2023.2.20f1.zip)
  4. unity6000.0.24f1：[UnityAndroidDemo6000.0.24f1.zip](https://github.com/TippingGame/F8Framework/blob/main/Runtime/SDKManager/Plugins_Android/AndroidPJ6000/UnityAndroidDemo6000.0.24f1.zip)  
------------------------------
* 打包成功后运行可以看到这个界面  
  1.如果你不想显示这个界面  
  2.请打开 [AndroidManifest.xml](https://github.com/TippingGame/F8Framework/blob/main/Runtime/SDKManager/Plugins_Android/AndroidPJ2021/Gradle6.1.1/AndroidManifest) 把 `MoeNativeActivity` 和 `MainActivity` 互换即可  
  3.[UnityAndroidDemo-release.aar](https://github.com/TippingGame/F8Framework/blob/main/Runtime/SDKManager/Plugins_Android/AndroidPJ2021/Gradle6.1.1/UnityAndroidDemo-release) 里面的 `AndroidManifest.xml` 也要修改  
  ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_20241119233017.png)  
---

## iOS工程使用方法
* 修改这两个文件对接SDK [F8SDKInterfaceUnity.h](https://github.com/TippingGame/F8Framework/blob/main/Plugins/iOS/SDKManager/F8SDKInterfaceUnity.h) 和 [F8SDKInterfaceUnity.mm](https://github.com/TippingGame/F8Framework/blob/main/Plugins/iOS/SDKManager/F8SDKInterfaceUnity.mm)

---
## WebGL游戏
#### 视频教程：[【Unity框架】（22）打包WebGL游戏](https://www.bilibili.com/video/BV1FnVozVEbG)
* 注意：WebGL不能使用同步加载 AB 资源，可同步加载 Resources 资源
---
## 微信小游戏接入方法
#### 视频教程：[【Unity框架】（23）打包微信小游戏](https://www.bilibili.com/video/BV1NugPzFESf)
* 浏览[WebGL转微信小游戏](https://github.com/wechat-miniprogram/minigame-unity-webgl-transform)插件的使用方法，下载[ unitypackage ](https://game.weixin.qq.com/cgi-bin/gamewxagwasmsplitwap/getunityplugininfo?download=1)并导入至游戏项目中
---
* 删除WX-WASM-SDK-V2插件里的`LitJson.dll`（注意：团结引擎也有，建议保留F8Framework里的）  
  ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_20240524000853.png)
* 分别给WX-WASM-SDK-V2目录下`Editor`和`Runtime`的两个`.asmdef`文件，添加F8框架的`LitJson`引用  
  ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_20240524001621.png)
---
* 修改三个变量为true。
1. [AssetManager.cs](https://github.com/TippingGame/F8Framework/blob/main/Runtime/AssetManager/AssetManager.cs)
```C#
//强制更改资产加载模式为远程（微信小游戏使用）
public static bool ForceRemoteAssetBundle = false;
```
* 使用强制远程加载模式后，需要将完整的 AssetBundles 目录上传至 CDN  
![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_1752739146608.png)  
2. [ABBuildTool.cs](https://github.com/TippingGame/F8Framework/blob/main/Editor/AssetManager/ABBuildTool.cs)
```C#
// 打包后AB名加上MD5（微信小游戏使用）
private static bool appendHashToAssetBundleName = false;
```
3. [DownloadRequest.cs](https://github.com/TippingGame/F8Framework/blob/main/Runtime/AssetManager/DownloadRequest/DownloadRequest.cs)
```C#
// 禁用Unity缓存系统在WebGL平台（微信小游戏使用）
public static bool DisableUnityCacheOnWebGL = false;
```
---

* （注意）由于微信小游戏只能使用远程AB加载，请点击F5，配置好资产远程地址后构建一次游戏。  
  ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_20241203214539_2.png)  
* 也可以在此处直接修改 [GameVersion.json](https://github.com/TippingGame/F8Framework/blob/main/AssetMap/Resources/GameVersion.json) 里的 "AssetRemoteAddress" 参数  
  ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_20241203214624.png)  
* 构建设置。  
  ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_20240329230924.png)  

### 如构建失败：请尝试使用Unity自带的Build一次后再尝试

---

## 使用Jenkins进行远程打包

1. [下载Java SDK，演示用的 21.0.7 版本](https://www.oracle.com/cn/java/technologies/downloads/)
2. [下载Jenkins，演示用的 2.504.2 LTS 版本](https://www.jenkins.io/download/)，安装需使用本机管理员账号（否则打包可能失败）
   ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_1749999206518.png)  
3. 按顺序安装完成后，启动 jenkins
4. 创建一个 job，配置如下
   ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_1749788881032.png)  
   ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_1749788919208.png)  
5. Plugins 界面安装 Unity3d plugin
   ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_1749787027911.png)  
6. Tools 界面添加 Unity 版本
   ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_1749787076031.png)  
7. 复制 [config.xml](https://github.com/TippingGame/F8Framework/blob/main/Editor/Build/Jenkins/config.xml) 到 Jenkins 数据目录对应的 job 目录下
   ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_1749789384733.png)  
8. 重启 Jenkins 服务
   ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_1749790107926.png)  
9. （如需要修改 Unity 版本，名称根据上方 Tools 界面的为准）修改配置界面里的 Build Steps 的 Unity 版本
    ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_1749789502754.png)  
10. 最后调整参数（与编辑器的打包界面一致），进行打包
    ![image](https://tippinggame-1257018413.cos.ap-guangzhou.myqcloud.com/TippingGame/SDKManager/ui_1749789318664.png)  