# 更新日志

> 此文件记录了该软件包所有重要的变更，文件格式基于 [Keep a Changelog](http://keepachangelog.com/en/1.0.0/) 更新日志规范，且此项目版本号遵循 [语义化版本](http://semver.org/spec/v2.0.0.html) 规范

## [3.4.0] - 2025-12-29
### 新增
- **主线程调度器 (`UnityMainThreadDispatcher`)**: 新增了一个线程安全的 `UnityMainThreadDispatcher` 单例类。它允许您从任何后台线程（如网络接收线程）中安全地将任务（如更新UI、操作GameObject）调度到 Unity 的主线程上执行

### 更改
- ** 将DataCollection 、Enums.cs、EventHandler移动到Scripts/Models目录下，使其更符合项目结构规范，便于管理和查找核心数据结构和枚举定义

## [3.3.1] - 2025-12-26]
### 修复
- **`ScriptCollection`**: 不再使用样本导入的方式将DataCollection.cs和Enums.cs复制到项目中，改为打包成unitypackage文件，放在包目录下 

## [3.3.0] - 2025-10-30
### 新增
- **`JsonHelper`**: 添加了 `JsonConfigLoader<T>` 抽象基类，通过继承并重写 `FilePathInStreamingAssets` 属性，可以快速实现从 `StreamingAssets` 自动加载配置数据的功能
- **`JsonHelper`**: 添加了 `SingleTonJsonConfigLoader<T>` 抽象基类，为单例管理器提供了一个集成了自动加载 JSON 配置功能的便捷选项

### 更改
- **项目结构**: 将 `DataCollection.cs` 和 `Enums.cs` 中的示例数据修改为更通用的模板，以减少在新项目中的冲突

## [3.2.0] - 2025-07-24
### 新增
- **`JsonHelper`**: 添加了 `SaveToStreamingAssets` 和 `LoadFromStreamingAssets` 两个包装函数，简化了常用的对 `StreamingAssets` 文件夹的读写操作
- **`Singleton`**: `Instance` 属性现在会在实例为空时，自动调用 `FindFirstObjectByType<T>()` 在场景中查找现有实例，增强了代码的健壮性

### 更改
- **项目结构**: 将核心的 `Singleton.cs` 和 `JsonHelper.cs` 脚本移动到包的 `Runtime` 目录下，使其可以作为 UPM 包被其他模块依赖

## [3.1.0] - 2025-06-11
### 新增
- **`JsonHelper`**: 添加了 GZip 压缩与解压缩功能。现在 `Save` 和 `Load` 方法可以通过 `compress` 参数支持对大型 JSON 数据进行压缩，以减小文件体积
- **`JsonHelper`**: 添加了 `SaveToPersistent` 和 `LoadFromPersistent` 两个包装函数，用于在 `Application.persistentDataPath` 路径下快速读写文件

## [3.0.0] - 2025-05-22
### 新增
- **`JsonHelper`**: 初始版本发布，提供了一套基于 `Newtonsoft.Json` 的静态方法，用于将数据结构序列化为 JSON 文件或从文件中反序列化

## [2.0.0] - 2025-03-07
### 移除
- **项目结构**: 删除了不再使用的 `Constant.cs` 文件

## [1.0.0] - 2024-05-02
### 新增
- **初始版本发布**: 提供了项目常用的核心模块
- **`Singleton`**: 提供了泛型单例模式基类 `Singleton<T>`
- **`EventHandler`**: 提供了一个静态的全局事件中心，用于低耦合的模块间通信
- **`DataCollection` / `Enums`**: 提供了存放通用数据结构和枚举的模板文件