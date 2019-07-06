using Custom.Basic.Framework.Pinvoke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "123";
            IntPtr intptr = User32Extension.FindWindow(null, "123");
            if (intptr != IntPtr.Zero)
            {
                Console.WriteLine("找到");
                User32Extension.FlashWindow(intptr, true);
            }
            else
            {
                Console.WriteLine("没找到");
            }


            Console.ReadKey();
        }

    }
}
