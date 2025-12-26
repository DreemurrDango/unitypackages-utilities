# Unity 通用中枢模块 (Utilities Module)

## 概述

本模块是为 Unity 项目提供的一套基础工具和常用设计模式的集合，旨在作为其他功能模块的基石。它包含了泛型单例模式、强大的 JSON 数据读写帮助类，以及一套用于项目全局定义的模板文件（如事件中心、枚举等）

## 核心功能

*   **泛型单例模式 (`Singleton<T>`)**: 提供一个 `MonoBehaviour` 的泛型基类，只需继承即可快速实现单例模式，并支持在实例为空时自动在场景中查找
*   **JSON 帮助类 (`JsonHelper`)**:
    *   基于 `Newtonsoft.Json` 的静态类，提供强大的 `Save` 和 `Load` 功能
    *   支持数据压缩（GZip），可将大型 JSON 文件保存为更小的二进制格式
    *   内置对 `Application.persistentDataPath` 和 `Application.streamingAssetsPath` 两个常用路径的快捷读写方法
*   **自动配置加载器**:
    *   提供 `JsonConfigLoader<T>` 和 `SingleTonJsonConfigLoader<T>` 两个抽象基类，继承它们即可轻松实现从 `StreamingAssets` 中加载配置文件
*   **项目定义模板 (Samples)**:
    *   **`EventHandler`**: 一个静态的全局事件中心模板，用于实现模块间的低耦合通信
    *   **`Enums` / `DataCollection`**: 用于集中定义项目中所有通用枚举和数据结构的模板文件

---

## 依赖项

*   **Newtonsoft.Json for Unity**: 本模块的 `JsonHelper` 依赖于此包。请通过 Unity 包管理器搜索并安装 `com.unity.newtonsoft-json`

---

## 快速开始

### 1. 安装与设置

1.  通过 Unity 包管理器从 Git URL 或本地路径添加此包
2.  **导入核心定义文件**:
    *   在包目录下，找到名为 `ScriptCollection` 的unitypackage文件，双击将其导入到你的项目中
    *   这会将 `EventHandler.cs`, `Enums.cs` 和 `DataCollection.cs` 等模板文件复制到您项目的 `Assets/Utilities` 文件夹中。您可以在此路径下安全地修改它们以适应您的项目需求

### 2. `Singleton` 用法

让你的管理器类继承自 `Singleton<T>`

```csharp
// public class MyManager : Singleton<MyManager>
// {
//     // 当有额外的初始化动作时可重写 Awake 方法
//     protected override void Awake()
//     {
//         base.Awake(); // 确保调用基类的 Awake 来实现单例逻辑
//         // ... 你的初始化代码
//     }
//
//     public void DoSomething()
//     {
//         Debug.Log("MyManager is doing something!");
//     }
// }

// 在其他任何地方调用：
// MyManager.Instance.DoSomething();
```

### 3. `JsonHelper` 用法

#### 方式一：直接调用静态方法

```csharp
// [System.Serializable]
// public struct MyGameData
// {
//     public int level;
//     public float score;
// }
//
// MyGameData data = new MyGameData { level = 5, score = 1234.5f };
//
// // 保存到 StreamingAssets
// JsonHelper.SaveToStreamingAssets(data, "Configs/GameData.json");
//
// // 从 StreamingAssets 加载
// MyGameData loadedData;
// JsonHelper.LoadFromStreamingAssets("Configs/GameData.json", out loadedData);
```

#### 方式二：使用自动加载器

```csharp
// 1. 定义你的配置数据结构
// [System.Serializable]
// public struct GameConfig
// {
//     public string gameVersion;
//     public bool enableCheats;
// }

// 2. 创建一个继承自加载器的管理器
// public class ConfigManager : SingleTonJsonConfigLoader<GameConfig>
// {
//     // 3. 指定配置文件的路径
//     protected override string FilePathInStreamingAssets => "Configs/GameConfig.json";
// }

// 4. 在其他地方直接访问配置
// bool cheats = ConfigManager.Instance.Config.enableCheats;
```

### 4. `EventHandler` 用法

在导入 Samples 后，你可以在 `Assets/Samples/.../EventHandler.cs` 中定义你的全局事件

```csharp
// 在 EventHandler.cs 中定义事件
// public static event Action<int> OnPlayerScored;
// public static void CallPlayerScored(int score) => OnPlayerScored?.Invoke(score);

// 订阅方 (例如一个UI脚本)
// void Start()
// {
//     EventHandler.OnPlayerScored += UpdateScoreUI;
// }
// void OnDestroy()
// {
//     EventHandler.OnPlayerScored -= UpdateScoreUI;
// }
// private void UpdateScoreUI(int newScore) { /* ... */ }

// 发布方 (例如一个游戏逻辑脚本)
// void AddScore(int amount)
// {
//     // ...
//     EventHandler.CallPlayerScored(currentScore);
// }
```