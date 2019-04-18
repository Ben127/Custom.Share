using Custom.Basic.Framework.Pinvoke;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom.Winform.Examples
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            User32Extension.AnimateWindow(this.Handle, 1000, AnimateWindowFlags.AW_CENTER);
        }
    }
}
