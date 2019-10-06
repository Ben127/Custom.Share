using Custom.Basic.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Custom.Basic.Framework.Test.HelperTest
{
    /// <summary>
    /// CmdProgressHelperTest
    /// </summary>
    public class CmdProgressHelperTest
    {
        private string _cmdResult = "";

        [Fact]
        public void Execute()
        {
            CmdProgressHelper target = new CmdProgressHelper();
            string _cmdResult = target.Execute("ipconfig");

            string _cmdResult2 = target.ExecuteSync("ipconfig");

            Assert.True(_cmdResult.Length > 0);

        }

    }
}
