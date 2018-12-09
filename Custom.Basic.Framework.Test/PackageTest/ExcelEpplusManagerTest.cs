using Custom.Basic.Framework.Package.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Custom.Basic.Framework.Test.PackageTest
{
    /// <summary>
    /// ExcelEpplusManagerTest
    /// </summary>
    public class ExcelEpplusManagerTest
    {

        public class Books
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [Fact]
        public void ExportTest()
        {
            List<Books> result = new List<Books>()
            {
                new Books(){ Id=100, Name="西游记"},
                new Books(){ Id=100, Name="三国演义"},
                new Books(){ Id=100, Name="红楼梦"},
                new Books(){ Id=100, Name="大话西游"},
                new Books(){ Id=100, Name="日夜"},
                new Books(){ Id=100, Name="叶子"}
            };
            ExcelEpplusManager.Export(result, "test.xlsx");

            FileInfo fi = new FileInfo("test.xlsx");

            Assert.True(File.Exists(fi.FullName));
        }

    }
}
