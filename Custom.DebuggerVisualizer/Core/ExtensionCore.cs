using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.DebuggerVisualizer.V12.Core
{
    public static class ExtensionCore
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNotNullOrEmpty(this string str)
        {
            return !IsNullOrEmpty(str);
        }


        public static bool IsObjectNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsObjectNotNull(this object obj)
        {
            return !IsObjectNull(obj);
        }

    }
}
