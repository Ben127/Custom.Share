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
    /// VerificationImageHelperTest
    /// </summary>
    public class VerificationImageHelperTest
    {
        [Fact(DisplayName = "CutImagesTest")]
        public void CutImagesTest()
        {
            string file = @"123.jpg";
            var bitmap = VerificationImageHelper.CutImagesJoinAll(file);

            Assert.True(bitmap != null);

        }

    }
}
