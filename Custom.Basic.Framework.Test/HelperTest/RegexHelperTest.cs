using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Custom.Basic.Framework.Helper;

namespace Custom.Basic.Framework.Test.HelperTest
{
    /// <summary>
    /// RegexHelperTest
    /// </summary>
    public class RegexHelperTest
    {

        [Fact]
        public void ReplaceTest()
        {

            string source = "Hello world, long time no see";
            string pattern = "world";
            string result = source.RegexReplace(pattern, "benny");

            Assert.Equal(result, "Hello benny, long time no see");
        }

    }
}
