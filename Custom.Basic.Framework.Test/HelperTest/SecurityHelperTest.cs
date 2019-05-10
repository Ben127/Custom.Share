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
            source = "123";
            string result = SecurityHelper.DESEncryption(source);

            string desResult = "YQyIm3uG3cOg8=";
            string source2 = SecurityHelper.DESDecrypt(result);

            Assert.Equal(source, source2);

        }



    }
}
