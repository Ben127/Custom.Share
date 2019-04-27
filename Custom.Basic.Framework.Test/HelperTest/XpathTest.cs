using Custom.Basic.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Custom.Basic.Framework.Test.HelperTest
{
    /// <summary>
    /// XpathTest
    /// </summary>
    public class XpathTest
    {
        [Fact]
        public void GetStringByString()
        {
            string source = "<a>Hello world</a>";
            string result = XpathHelper.GetStringByString(source, "/a/text()");

            Assert.Equal("Hello world", result);

        }

    }
}
