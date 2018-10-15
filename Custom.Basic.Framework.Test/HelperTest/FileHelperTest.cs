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
    public class FileHelperTest
    {

        [Fact]
        public void WriteLogTest()
        {

            string fileName = "test.log";
            string msg = "Hello world";

            FileHelper.WriteLog(msg, fileName);

            // check file exists
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            Assert.True(File.Exists(path));

            // check file content
            string source = FileHelper.ReadFileContent(path);
            Assert.Equal(source, "Hello world\r\n");

        }

    }
}
