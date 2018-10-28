using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Custom.Basic.Framework.Common;

namespace Custom.Basic.Framework.Test.CommonTest
{
    /// <summary>
    /// CacheManageTest
    /// </summary>
    public class CacheManageTest
    {

        public enum Enum_CacheKey
        {
            Test,
            Add
        }


        private void Init()
        {
            Dictionary<int, string> cacheList = new Dictionary<int, string>()
            {
                {1, "Hello" },
                {2,"World"},
                {3,"Benny"},
                {4,"Nice"}
            };

            CacheManager.Add<Enum_CacheKey, int, string>(Enum_CacheKey.Test, cacheList);

            Dictionary<string, string> cacheList2 = new Dictionary<string, string>()
            {
                {"admin", "123" },
                {"test","123"},
                {"sa","sa123"},
            };

            CacheManager.Add<Enum_CacheKey, string, string>(Enum_CacheKey.Add, cacheList2);

        }


        [Fact(DisplayName = "缓存添加")]
        public void AddTest()
        {
            Init();
            var result = CacheManager.CacheView;
            Assert.True(CacheManager.Exists(Enum_CacheKey.Test));
        }

        [Fact(DisplayName = "获取一个字典项字典值")]
        public void GeTest()
        {
            Init();

            string result = CacheManager.Get<Enum_CacheKey, int, string>(Enum_CacheKey.Test, 1);
            Assert.Equal(result, "Hello");

        }

        [Fact(DisplayName = "移除字典项键Test")]
        public void RemoveTest()
        {
            Init();

            Assert.True(CacheManager.Remove(Enum_CacheKey.Test));
        }

        [Fact(DisplayName = "移除字典项Add 缓存的某个键")]
        public void RemoveOneTest()
        {
            Init();

            Assert.True(CacheManager.Remove<Enum_CacheKey, string, string>(Enum_CacheKey.Add, "sa"));
        }

        [Fact(DisplayName = "清空缓存", Skip = "暂不测试")]
        public void ClearTest()
        {
            Init();

            CacheManager.ClearAll();

            Assert.True(CacheManager.CacheView.Count == 0);
        }


    }
}
