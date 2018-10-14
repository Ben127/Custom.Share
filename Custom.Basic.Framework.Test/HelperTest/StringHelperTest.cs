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
    /// StringHelperTest
    /// </summary>
    public class StringHelperTest
    {
        [Fact]
        public void IsNullOrEmptyTest()
        {
            string source = null;
            Assert.True(source.IsNullOrEmpty());
        }


        [Fact]
        public void IsNullOrWhiteSpaceTest()
        {
            string source = null;
            Assert.True(source.IsNullOrWhiteSpace());
        }


        [Fact]
        public void JoinTest()
        {
            List<string> source = new List<string>() { "我", "爱", "我", "家" };
            string result = "我|爱|我|家";
            Assert.Equal(result, source.Join("|"));
        }


        [Fact]
        public void SubstrTest()
        {
            string source = "helloworld您好";
            string result = "helloworld";
            Assert.Equal(result, source.Substr(0, 10));
        }



    }
}
