# Changelog

## [1.0.62] - 2024-11-09
1.优化资产模块加载类型不一致提示  
2.优化本地化模块代码  

## [1.0.61] - 2024-11-09
1.#19 本地化模块增加字体切换，优化代码  

## [1.0.60] - 2024-11-08
1.修复资产模块Scene异步加载失败问题  

## [1.0.59] - 2024-11-07
1.优化资产模块协程并行加载  

## [1.0.58] - 2024-11-06
1.优化文档，删除多余图片  

## [1.0.57] - 2024-11-06
1.#18 本地化模块不再依赖资产，可使用id索引资产。如添加多张图片，改为只需要一个id  
2.修复资产模块展开资源时类型错误的问题  

## [1.0.56] - 2024-11-04
1.优化资产模块，编辑器模式下增加缓存，加快搜索速度  

## [1.0.55] - 2024-11-04
1.修复资产模块协程同时加载报错的问题  

## [1.0.54] - 2024-11-03
1.优化游戏对象池模块初始化预加载对象数量显示  

## [1.0.53] - 2024-11-03
1.游戏对象池模块增加Spawn By PrefabName方法  

## [1.0.52] - 2024-11-03
1.游戏对象池模块增加GetPoolByPrefabName方法  

## [1.0.51] - 2024-11-01
1.补间动画模块增加对Material的动画  
2.声音模块新增缓存音频/UnloadAll移除所有音频接口  
3.完善文档  

## [1.0.50] - 2024-10-31
1.声音模块，声音播放增加淡入参数fadeDuration，3D特效播放增加spatialBlend和maxNum参数  
2.声音模块，补间/缓动模块，游戏对象池模块，优化文档  
3.移除UI模块自动调用Unload，因为音频未播放完会报错  

## [1.0.49] - 2024-10-30
1.修改默认表格名称，修复StreamingAssets目录下存在中文打包错误的问题  
2.修复Resources目录资产异步加载报错问题  
3.优化声音模块组件判空  

## [1.0.48] - 2024-10-26
1.修复事件系统调用到不同id事件的问题  

## [1.0.47] - 2024-10-23
1.修复事件系统嵌套调用会报错的问题，防止死循环优化  

## [1.0.46] - 2024-10-23
1.音频AB包移除自动卸载  

## [1.0.45] - 2024-10-22
1.Resources卸载资产区分是否完全卸载  

## [1.0.44] - 2024-10-20
1.完善文档  

## [1.0.43] - 2024-10-19
1.修复配置表可能被代码裁剪的问题  

## [1.0.42] - 2024-10-18
1.完善文档  

## [1.0.41] - 2024-10-17
1.修改AssetMap代码的位置  

## [1.0.40] - 2024-10-17
1.完善文档  
2.不再依赖Tests文件夹内容，可按需删除  
3.修复自动绑定组件找不到GameObject的问题  

## [1.0.39] - 2024-10-16
1.更新第三方库，完善第三方库引用文档  
2.完善UI文档，构建文档  

## [1.0.38] - 2024-10-14
1.增加UI模块使用枚举值传入Open的方法  
2.优化UI模块OnDestroy方法  

## [1.0.37] - 2024-10-12
1.优化导表存放位置的提示  
2.优化资产模块加载的方法  

## [1.0.36] - 2024-09-30
1.优化构建文档  
2.优化EditorPrefs，多个工程使用不同Key值  

## [1.0.35] - 2024-09-28
1.优化WebGL下加载资源方法  

## [1.0.34] - 2024-09-11
1.新增缺少EventSystem提示  

## [1.0.33] - 2024-09-11
1.新增自动复制AndroidManifest和mainTemplate  
2.新增UI模块设置Canvas和CanvasScaler属性的方法  

## [1.0.32] - 2024-09-06
1.修复配置表sheet名不能使用Item关键字的问题  
2.新增可以更改配置表路径  
3.新增配置表字段类型  

## [1.0.31] - 2024-08-18
1.优化UI模块不再强制设置UI的位置和旋转  

## [1.0.30] - 2024-08-18
1.优化UI模块Instantiate传入默认参数  

## [1.0.29] - 2024-08-18
1.优化UI模块Added方法执行顺序  

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