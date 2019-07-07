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
            intptr = User32Extension.FindWindow("ConsoleWindowClass", null);

            //if (intptr != IntPtr.Zero)
            //{
            //    Console.WriteLine("找到");
            //    User32Extension.FlashWindow(intptr, true);
            //}
            //else
            //{
            //    Console.WriteLine("没找到");
            //}


            var vvv = GetAllDesktopWindows().Where(p => p.szWindowName == "微信");
            foreach (var item in vvv)
            {
                Console.WriteLine(string.Format("hWnd：{0,-10}   className：{1,-20}   WindowName：{2}", item.hWnd, item.szClassName, item.szWindowName));
                User32Extension.FlashWindow(item.hWnd, true);
            }

            Console.ReadKey();
        }



        private delegate bool WNDENUMPROC(IntPtr hWnd, int lParam);
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, int lParam);
        //[DllImport("user32.dll")] 
        //private static extern IntPtr FindWindowW(string lpClassName, string lpWindowName); 
        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        public struct WindowInfo
        {
            public IntPtr hWnd;
            public string szWindowName;
            public string szClassName;
        }

        public static WindowInfo[] GetAllDesktopWindows()
        {
            List<WindowInfo> wndList = new List<WindowInfo>();

            //enum all desktop windows 
            EnumWindows(delegate(IntPtr hWnd, int lParam)
            {
                WindowInfo wnd = new WindowInfo();
                StringBuilder sb = new StringBuilder(256);
                //get hwnd 
                wnd.hWnd = hWnd;
                //get window name 
                GetWindowTextW(hWnd, sb, sb.Capacity);
                wnd.szWindowName = sb.ToString();
                //get window class 
                GetClassNameW(hWnd, sb, sb.Capacity);
                wnd.szClassName = sb.ToString();
                //add it into list 
                if (wnd.szWindowName.IndexOf("QQ2013") != -1)
                {
                    WindowInfo aa = wnd;
                }
                wndList.Add(wnd);
                return true;
            }, 0);

            return wndList.ToArray();
        }



    }
}
