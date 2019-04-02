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
    /// TimeHelperTest
    /// </summary>
    public class TimeHelperTest
    {
        [Fact(DisplayName = "TimeHelperTest")]
        public void ToUnixTimeTest()
        {
            var d = (new DateTime(1975, 1, 3, 5, 3, 2, DateTimeKind.Utc)).ToUnixTime();
            Assert.Equal(157957382000L, d);
        }

    }
}
