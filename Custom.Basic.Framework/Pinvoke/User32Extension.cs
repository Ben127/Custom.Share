using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Pinvoke
{
    /// <summary>
    /// User32 api
    /// </summary>
    public class User32Extension
    {
        /// <summary>
        ///  窗体闪动
        /// </summary>        
        /// <param name="hwnd">窗体字柄</param>
        /// <param name="bInvert">是否闪动</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool FlashWindow(IntPtr hwnd, bool bInvert);

        /// <summary>
        ///  窗体效果
        /// </summary>
        /// <param name="hwnd">窗体字柄</param>
        /// <param name="time">毫秒</param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool AnimateWindow(IntPtr hwnd, int time, AnimateWindowFlags flags);

        /// <summary>
        /// 查找窗体字柄
        /// <para>
        ///         FindWindow(null,"窗体标题")
        ///         FindWindow("Notepad", null)
        /// </para>
        /// </summary>
        /// <param name="lpClassName"> 窗口类名</param>
        /// <param name="lpWindowName"> 窗口名称（窗口标题）</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 查找窗体/控件字柄
        /// <para>
        ///     IntPtr ButtonHwnd= FindWindowEx(hwnd, IntPtr.Zero, "控件的名字", null)
        /// </para>
        /// </summary>
        /// <param name="hwndParent">父窗体字柄，如果为null 桌面窗口作为父窗口</param>
        /// <param name="hwndChildAfter">子窗口字柄，如果为空则搜索第一个子窗口</param>
        /// <param name="lpszClass">窗口类名</param>
        /// <param name="lpszWindow"> 窗口名称（窗口标题）</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);


    }
}
