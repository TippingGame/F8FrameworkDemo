# Changelog

## [1.0.28] - 2024-08-15
1.修复资产模块在编辑器模式下，加载新资源失败的问题  

## [1.0.27] - 2024-08-11
1.优化UI系统Guid标识，Dialog和Notify类型界面正确使用缓存  
2.增加收集UI所有的中文编辑器功能  

## [1.0.26] - 2024-08-07
1.输入系统增加按钮Started、Performed、Canceled回调，Axis增加ValueChanged回调  

## [1.0.25] - 2024-08-07
1.修复资产的文件名和ab名不一致时，加载文件夹内资产失败问题  

## [1.0.24] - 2024-08-01
1.#14 修复本地数据存储没有拼接user问题  
2.暂时屏蔽Reset和OnValidate时自动获取组件  

## [1.0.23] - 2024-07-05
1.修正构建时根据当前平台导出的表现  

## [1.0.22] - 2024-07-03
1.AudioEffect3D使用游戏对象池  
2.游戏对象池模块添加轮询，默认DontDestroyOnLoad = true，默认CheckForPrefab = true  
3.AudioMixer优化使侧链压缩/闪避效果更突出  

## [1.0.21] - 2024-07-01
1.等待编译完成后生成复制热更新Dll  
2.UI系统UICallbacks修正为使用传入的参数  

## [1.0.20] - 2024-06-29
1.LogViewer开启发送邮件功能  
2.优化Log调色盘GC  
3.资产管理Demo增加Scene加载用法  

## [1.0.19] - 2024-06-23
1.构建项目顺序改为等待编译完成  

## [1.0.18] - 2024-06-22
1.修复打包热更包的资产后缀被错误删除  
2.热更新计算Size大小时增加判空  
3.CreateModule存在模块时增加返回  
4.完善热更文档  

## [1.0.17] - 2024-06-21
1.新增F8Framework.F8ExcelDataClass和F8Framework.Launcher程序集  
2.配置表生成的F8Framework.F8ExcelDataClass可用于HybridCLR热更  
3.增加导表后脚本编译完成，再打包AB步骤  
4.重新加载C#域后，AssetDatabase.Refresh需要增加delayCall延迟执行  
5.完善热更文档  
6.F8Framework.Tests程序集增加宏定义不参与打包  

## [1.0.16] - 2024-05-26
1.优化资产管理代码  
2.优化UI界面传入参数  

## [1.0.15] - 2024-05-24
1.增加英文文档  
2.中文文档图片使用国内地址  
3.微信小游戏完善文档  

## [1.0.14] - 2024-05-20
1.资产AssetPath改为小写，限制ToLower()数量

## [1.0.13] - 2024-05-19
1.修复相同AB名下获取资产失败问题  
2.明确AB资产地址(大小写不敏感)  

## [1.0.12] - 2024-05-18
1.增加BaseItem组件  
2.事件系统增加移除事件所有监听的方法  

## [1.0.11] - 2024-05-17
1.编辑器模式下加载资源改为自动搜索AssetPath

## [1.0.10] - 2024-05-16
1.AssetBundleMap.json中只保留一个AssetPath，改为从AssetBundle中GetAllAssetNames方法获取  
2.由于GetAllAssetNames只能获取小写的AssetPath，需修改GetLoadProgress和GetAssetObject方法  

## [1.0.9] - 2024-05-12
1.Network模块代码优化GC

## [1.0.8] - 2024-05-09
1.输入模块增加GetAxisRaw

## [1.0.7] - 2024-05-09
1.Network模块代码优化

## [1.0.6] - 2024-05-09
1.本地化表移除实时监控

## [1.0.5] - 2024-05-08
1.本地化表TextID可为空

## [1.0.4] - 2024-05-08
1.热更新增加校验本地资源md5  
2.分包下载增加断点续传  

## [1.0.3] - 2024-05-02
1.InitializeOnLoadMethod统一管理调用顺序

## [1.0.2] - 2024-04-09
1.LitJson序列化增加UnityEngine基础类型，增加跳过序列化特性[JsonIgnore]

## [1.0.1] - 2024-04-03
1.添加UI红点组件及示例

## [1.0.0] - 2023-12-10
UnityF8Framework核心功能
