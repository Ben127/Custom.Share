using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.DebuggerVisualizer.Core
{
    /// <summary>
    /// ToolHelper
    /// </summary>
    public class ToolHelper
    {

        private const long Size_1K = 1024;
        private const long Size_1M = 1024 * 1024;
        private const long Size_1G = 1024 * 1024 * 1024;

        public static string GetSize(long filesize)
        {
            if (filesize < Size_1K)
            {
                return filesize + " B";
            }
            else if (filesize >= Size_1K && filesize < Size_1M)
            {
                return (Math.Round(filesize / (decimal)Size_1K)) + " K " + GetSize(filesize % Size_1K);
            }
            else if (filesize >= Size_1M && filesize < Size_1G)
            {
                return (Math.Round(filesize / (decimal)Size_1M)) + " M " + GetSize(filesize % Size_1M);
            }
            else if (filesize >= Size_1G)
            {
                return (Math.Round(filesize / (decimal)Size_1G)) + " G " + GetSize(filesize % Size_1G);
            }
            return "";

        }



        private const int Time_1Min = 60;
        private const int Time_1H = 60 * 60;

        public static string GetTime(double seconds)
        {
            if (seconds < Time_1Min)
            {
                return seconds + " s";
            }
            else if (seconds >= Time_1Min && seconds < Time_1H)
            {
                return (Math.Round(seconds / Time_1Min)) + " min " + GetTime(seconds % Time_1Min);
            }
            else
            {
                return (Math.Round(seconds / Time_1H)) + " h " + GetTime(seconds % Time_1H);
            }

        }


    }
}
