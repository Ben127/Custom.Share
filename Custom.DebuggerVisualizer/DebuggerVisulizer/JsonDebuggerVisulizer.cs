using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Custom.DebuggerVisualizer.Core;
using Microsoft.VisualStudio.DebuggerVisualizers;

[assembly: System.Diagnostics.DebuggerVisualizer(
typeof(Custom.DebuggerVisualizer.JsonDebuggerVisulizer),
typeof(VisualizerObjectSource),
Target = typeof(string),
Description = "JSON Visualizer")]

namespace Custom.DebuggerVisualizer
{
    public class JsonDebuggerVisulizer : CustomDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            string content = objectProvider.GetObject().ToString();
            Form form = CreateForm(content);
            windowService.ShowDialog(form);
        }

        private Form form = null;
        private Label lblOldName = null;
        private Label lblNewName = null;
        private TextBox txtOldName = null;
        private RichTextBox rtbNewName = null;

        private Form CreateForm(string content)
        {
            form = new Form();

            lblOldName = new Label();
            lblNewName = new Label();

            txtOldName = new TextBox();
            rtbNewName = new RichTextBox();

            // form
            form.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            form.ClientSize = new System.Drawing.Size(661, 470);
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.Name = "Form1";
            form.ShowIcon = false;
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            form.Text = "JSON可视化工具";

            form.SuspendLayout();

            // lblOldName
            lblOldName.AutoSize = true;
            lblOldName.Location = new System.Drawing.Point(33, 27);
            lblOldName.Name = "lblOldName";
            lblOldName.Size = new System.Drawing.Size(53, 12);
            lblOldName.TabIndex = 0;
            lblOldName.Text = "表达式：";

            // lblNewName
            lblNewName.AutoSize = true;
            lblNewName.Location = new System.Drawing.Point(33, 71);
            lblNewName.Name = "lblNewName";
            lblNewName.Size = new System.Drawing.Size(53, 12);
            lblNewName.TabIndex = 0;
            lblNewName.Text = "格式化：";

            // txtOldName
            txtOldName.Location = new System.Drawing.Point(92, 24);
            txtOldName.Name = "txtOldName";
            txtOldName.ReadOnly = true;
            txtOldName.Size = new System.Drawing.Size(512, 21);
            txtOldName.TabIndex = 1;
            txtOldName.Text = content.Trim();

            // rtbNewName
            rtbNewName.CausesValidation = false;
            rtbNewName.Location = new System.Drawing.Point(92, 71);
            rtbNewName.Name = "rtbNewName";
            rtbNewName.ReadOnly = true;
            rtbNewName.Size = new System.Drawing.Size(512, 361);
            rtbNewName.TabIndex = 0;
            rtbNewName.Text = "";

            form.Controls.Add(rtbNewName);
            form.Controls.Add(txtOldName);
            form.Controls.Add(lblNewName);
            form.Controls.Add(lblOldName);

            form.PerformLayout();
            form.ResumeLayout(false);

            // event
            form.Load += Load;

            return form;
        }


        // 加载后
        protected void Load(object sender, EventArgs e)
        {
            string str = txtOldName.Text;

            //todo  json parse
            string newStr = new JSONHelper().Format(str);

            rtbNewName.Text = newStr;

        }







    }
}
