using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Custom.DebuggerVisualizer.V12.Core;

namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    public partial class JsonView : Form
    {
        public JsonView()
        {
            InitializeComponent();
        }

        private string _input;
        public JsonView(string input)
            : this()
        {
            _input = input;
        }

        private void JsonView_Load(object sender, EventArgs e)
        {
            if (_input.IsNullOrEmpty())
            {
                toolLog.Text = Log("转换失败，错误json格式");
                return;
            }
            try
            {
                var result = new Custom.DebuggerVisualizer.Core.JSONHelper().Format(_input);
                rtbResult.Text = result;

                toolLog.Text = Log("转换json格式结果");
            }
            catch (Exception ex)
            {
                rtbResult.Text = ex.Message + "\n" + ex.Source;
                return;
            }
        }


        private string Log(string message)
        {
            return string.Format("[{0}]：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
        }

        private void btnClipboard_Click(object sender, EventArgs e)
        {
            if (rtbResult.Text.IsNotNullOrEmpty())
            {
                Clipboard.SetText(rtbResult.Text);
                toolLog.Text = Log("复制到粘贴板 Success");
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClipboard_Click(null, null);
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string result = Clipboard.GetText();
            if (result.IsNotNullOrEmpty())
            {
                rtbResult.Text = result;
            }
        }


    }
}
