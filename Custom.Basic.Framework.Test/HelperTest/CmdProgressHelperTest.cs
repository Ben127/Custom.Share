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
            target.OnGetCmdMessage += target_OnGetCmdMessage;
            target.Execute("ipconfig");

            while (_cmdResult.Length == 0)
            {
                Console.WriteLine(_cmdResult);
                Thread.Sleep(1000);
            }

            //_cmdResult = target.SyncExecute("ipconfig");

            Assert.True(_cmdResult.Length > 0);

        }

        void target_OnGetCmdMessage(object sender, string InfoMessage, CmdProgressHelper.RedirectOutputType redirectOutputType)
        {
            _cmdResult = InfoMessage;
            Console.WriteLine(InfoMessage);
        }

    }
}
