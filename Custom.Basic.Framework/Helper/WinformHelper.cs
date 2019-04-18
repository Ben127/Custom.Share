using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
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
        #region 1 窗体移动


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

        #endregion


        #region 2 圆角

        /// <summary>
        /// 圆角界面
        /// </summary>
        public static void OnRoundView(Form frm)
        {
            GraphicsPath formPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, frm.Width, frm.Height);
            int dimeter = 18;
            Rectangle arc = new Rectangle(rect.Location, new Size(dimeter, dimeter));
            formPath.AddArc(arc, 180, 90);  //右上
            arc.X = rect.Right - dimeter;
            formPath.AddArc(arc, 270, 90);  //右下
            arc.Y = rect.Bottom - dimeter;
            formPath.AddArc(arc, 0, 90);    //左上
            arc.X = rect.Left;
            formPath.AddArc(arc, 90, 90);   //左下
            formPath.CloseFigure();

            frm.Region = new Region(formPath);
        }

        /// <summary>
        /// 控件圆角界面
        /// </summary>
        /// <param name="control"></param>
        public static void OnRoundView(Control control)
        {
            GraphicsPath formPath = new GraphicsPath();
            Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
            int dimeter = 18;
            Rectangle arc = new Rectangle(rect.Location, new Size(dimeter, dimeter));
            formPath.AddArc(arc, 180, 90);  //右上
            arc.X = rect.Right - dimeter;
            formPath.AddArc(arc, 270, 90);  //右下
            arc.Y = rect.Bottom - dimeter;
            formPath.AddArc(arc, 0, 90);    //左上
            arc.X = rect.Left;
            formPath.AddArc(arc, 90, 90);   //左下
            formPath.CloseFigure();

            control.Region = new Region(formPath);
        }

        /// <summary>
        /// 控件集合圆角界面
        /// </summary>
        /// <param name="controls">控件集合</param>
        public static void OnRoundView(Control[] controls)
        {
            foreach (Control control in controls)
            {
                GraphicsPath formPath = new GraphicsPath();
                Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
                int dimeter = 18;
                Rectangle arc = new Rectangle(rect.Location, new Size(dimeter, dimeter));
                formPath.AddArc(arc, 180, 90);  //右上
                arc.X = rect.Right - dimeter;
                formPath.AddArc(arc, 270, 90);  //右下
                arc.Y = rect.Bottom - dimeter;
                formPath.AddArc(arc, 0, 90);    //左上
                arc.X = rect.Left;
                formPath.AddArc(arc, 90, 90);   //左下
                formPath.CloseFigure();

                control.Region = new Region(formPath);
            }
        }

        #endregion


        #region 3 水印

        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        private static extern Int32 SendMessage
          (IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        /// <summary>
        /// 为TextBox设置水印文字
        /// </summary>
        /// <param name="textBox">TextBox</param>
        /// <param name="watermark">水印文字</param>
        public static void OnSetWatermark(TextBox textBox, string watermark)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermark);
        }
        /// <summary>
        /// 清除水印文字
        /// </summary>
        /// <param name="textBox">TextBox</param>
        public static void OnClearWatermark(TextBox textBox)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, string.Empty);
        }

        #endregion

    }
}
