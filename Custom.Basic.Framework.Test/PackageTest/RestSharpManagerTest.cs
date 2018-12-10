using Custom.Basic.Framework.Package.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Custom.Basic.Framework.Test.PackageTest
{
    /// <summary>
    /// RestSharpManagerTest
    /// </summary>
    public class RestSharpManagerTest
    {
        [Fact]
        public void GetTest()
        {
            string url = "https://www.baidu.com/s?ie=UTF-8&wd=c%23";
            string html = RestSharpManager.Get(url);

            Assert.True(html != null);

        }

        [Fact]
        public void GetTest2()
        {
            // 等同于 https://www.baidu.com/s?ie=UTF-8&wd=c%23
            string url = "https://www.baidu.com/s";
            string html = RestSharpManager.Get(url, null, null, null, new Dictionary<string, object> { { "ie", "UTF-8" }, { "wd", "c#" } });

            Assert.True(html != null);

        }

    }
}
