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
    /// SecurityHelperTest
    /// </summary>
    public class SecurityHelperTest
    {
        [Fact]
        public void RSAEncryptionTest()
        {
            string source = "Hello world";
            string result = SecurityHelper.RSAEncryption(source);

            string source2 = SecurityHelper.RSADecrypt(result);

            Assert.Equal(source, source2);

        }



    }
}
