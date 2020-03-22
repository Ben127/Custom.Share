using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    public partial class CollectionViewMainDetail : Form
    {
        public CollectionViewMainDetail()
        {
            InitializeComponent();
        }


        private string result;
        public CollectionViewMainDetail(string result)
            : this()
        {
            this.result = result;
        }

        private void CollectionDetailView_Load(object sender, EventArgs e)
        {
            rtb_Result.Clear();
            rtb_Result.Text = this.result;
        }

        private void ts_copy_ButtonClick(object sender, EventArgs e)
        {
            Clipboard.SetText(this.result);
        }



    }
}
