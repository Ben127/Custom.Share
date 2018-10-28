using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Custom.Basic.Framework.Helper;
using System.IO;

namespace Custom.Basic.Framework.Test.HelperTest
{
    /// <summary>
    /// FileHelperTest
    /// </summary>
    public class LogHelperTest
    {

        [Fact]
        public void WriteLogTest()
        {

            string fileName = "test.log";
            string msg = "Hello world";

            LogHelper.ErrorLog(msg);
            LogHelper.InfoLog("程序测试....");

            // check file exists
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            Assert.True(File.Exists(path));

            // check file content
            string source = LogHelper.ReadContent(path);
            Assert.Equal(source, "Hello world\r\n");

        }

    }
}
