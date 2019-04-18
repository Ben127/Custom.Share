using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// WinformHelper
    /// </summary>
    public class WinformHelper
    {
        #region   全局变量
        private static int x, y;
        #endregion
        /// <summary>
        /// 鼠标按下时发生
        /// </summary>
        /// <param name="e">鼠标事件</param>
        public static void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }
        /// <summary>
        /// 鼠标移过组件发生
        /// </summary>
        /// <param name="e">鼠标事件</param>
        /// <param name="frm">窗体</param>
        public static void OnMouseMove(MouseEventArgs e, Form frm)
        {
            if (e.Button == MouseButtons.Left)
            {
                frm.Left += e.X - x;
                frm.Top += e.Y - y;
            }
        }

    }
}
