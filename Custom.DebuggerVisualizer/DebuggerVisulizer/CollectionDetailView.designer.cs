namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    partial class CollectionDetailView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectionDetailView));
            this.rtb_Result = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts_copy = new System.Windows.Forms.ToolStripSplitButton();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_Result
            // 
            this.rtb_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Result.Location = new System.Drawing.Point(10, 10);
            this.rtb_Result.Name = "rtb_Result";
            this.rtb_Result.Size = new System.Drawing.Size(804, 564);
            this.rtb_Result.TabIndex = 0;
            this.rtb_Result.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_copy});
            this.statusStrip1.Location = new System.Drawing.Point(10, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(804, 23);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ts_copy
            // 
            this.ts_copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_copy.Image = ((System.Drawing.Image)(resources.GetObject("ts_copy.Image")));
            this.ts_copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_copy.Name = "ts_copy";
            this.ts_copy.Size = new System.Drawing.Size(96, 21);
            this.ts_copy.Text = "复制到粘贴板";
            this.ts_copy.ButtonClick += new System.EventHandler(this.ts_copy_ButtonClick);
            // 
            // CollectionDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 584);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.rtb_Result);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CollectionDetailView";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "泛型数据可视化 v1.0";
            this.Load += new System.EventHandler(this.CollectionDetailView_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_Result;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton ts_copy;
    }
}