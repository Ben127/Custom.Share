using Custom.Basic.Framework.Package;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Custom.Basic.Framework.Test.GuidTest
{
    /// <summary>
    /// GuidManagerTest
    /// </summary>
    public class GuidManagerTest
    {
        [Fact]
        public void CreateTest()
        {
            for (int i = 0; i < 10; i++)
            {
                string result = GuidManager.Create(SequentialGuidType.SequentialAsBinary).ToString();
                Debug.WriteLine(result);
            }

            Assert.True(true);
        }

    }
}
