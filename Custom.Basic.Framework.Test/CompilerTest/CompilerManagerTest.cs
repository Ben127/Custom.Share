using Custom.Basic.Framework.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Custom.Basic.Framework.Test.CompilerTest
{
    /// <summary>
    /// CompilerManagerTest
    /// </summary>
    public class CompilerManagerTest
    {
        [Fact]
        public void ExcuteTest()
        {
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.AppendLine(" class Program");
            stringbuilder.AppendLine("{");
            stringbuilder.AppendLine("    public string Main() {");
            stringbuilder.AppendLine("          return \"Hello world\"; ");
            stringbuilder.AppendLine("                             }");
            stringbuilder.AppendLine("}");

            CompilerManager.Add("petapoco");

            string result = CompilerManager.Excute(stringbuilder.ToString(), "Main") as string;

            Assert.Equal(result, "Hello world");

        }

    }
}
