using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// TimeHelper
    /// </summary>
    public static class TimeHelper
    {
        private static readonly DateTime Time19700101 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Unix 时间戳是从格林威治时间1970 年 01 月 01 日 00 时 00 分 00 秒(北京时间 1970 年 01 月 01 日 08 时 00 分 00 秒)起至现在的总秒数
        /// </summary>
        /// <param name="time">要转换的时间</param>
        /// <returns></returns>
        public static long ToUnixTime(this DateTime time)
        {
            return (long)Math.Round(time.ToUniversalTime().Subtract(Time19700101).TotalMilliseconds,
                MidpointRounding.AwayFromZero);
        }

    }
}
