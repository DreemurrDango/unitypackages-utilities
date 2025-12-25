using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Utilities.JsonHelpTest
{
    [System.Serializable]
    public struct TestData
    {
        public int id;
        public string name;
        public float value;
    }

    /// <summary>
    /// 用于测试JsonConfigDataLoader的类
    /// </summary>
    public class JsonHelperTest : SingleTonJsonConfigLoader<TestData>
    {
        protected override string FilePathInStreamingAssets => "jsonHelperTest.json";
    }
}
