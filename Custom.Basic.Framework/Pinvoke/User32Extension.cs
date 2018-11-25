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

    }
}
