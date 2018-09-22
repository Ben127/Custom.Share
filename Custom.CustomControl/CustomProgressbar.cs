using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom.CustomControl
{
    /// <summary>
    /// CustomProgressbar
    /// </summary>
    [ToolboxItem(true)]
    public class CustomProgressbar : System.Windows.Forms.ProgressBar
    {
        /// <summary>
        /// 获取整个窗口DC
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        /// <summary>
        /// 释放设备上下文环境DC
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hDC"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);


        private System.Drawing.Color _TextColor = System.Drawing.Color.Black;

        private System.Drawing.Font _TextFont = new System.Drawing.Font("yaHei ", 12);

        public System.Drawing.Color TextColor
        {

            get { return _TextColor; }

            set { _TextColor = value; this.Invalidate(); }

        }

        public System.Drawing.Font TextFont
        {

            get { return _TextFont; }

            set { _TextFont = value; this.Invalidate(); }

        }


        /// <summary>
        /// 重写消息处理函数WndProc
        ///         OnPaint  由   Windows   完成其所有绘图的控件（例如   Textbox）从不调用它们的   OnPaint   方法
        ///         拦截系统消息，获得当前控件进程以便重绘
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref  Message m)
        {

            base.WndProc(ref   m);

            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                IntPtr hDC = GetWindowDC(m.HWnd);

                if (hDC.ToInt32() == 0)
                    return;

                System.Drawing.Graphics g = Graphics.FromHdc(hDC);
                SolidBrush brush = new SolidBrush(_TextColor);
                string s = string.Format("{0}%", this.Value * 100 / this.Maximum);
                SizeF size = g.MeasureString(s, _TextFont);
                float x = (this.Width - size.Width) / 2;
                float y = (this.Height - size.Height) / 2;
                g.DrawString(s, _TextFont, brush, x, y);

                //返回结果  
                m.Result = IntPtr.Zero;

                //释放  
                ReleaseDC(m.HWnd, hDC);

            }

        }

    }
}
