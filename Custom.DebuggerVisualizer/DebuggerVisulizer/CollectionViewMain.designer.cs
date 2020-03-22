namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    partial class CollectionViewMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectionViewMain));
            this.toolLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.查看详情ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出选中列txtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripLabel();
            this.ts_Index = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_btnReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_btnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_ExcelCurrent = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ts_combox = new System.Windows.Forms.ToolStripComboBox();
            this.ts_search_content = new System.Windows.Forms.ToolStripTextBox();
            this.隐藏该列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolLog
            // 
            this.toolLog.Name = "toolLog";
            this.toolLog.Size = new System.Drawing.Size(23, 17);
            this.toolLog.Text = "---";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLog});
            this.statusStrip1.Location = new System.Drawing.Point(0, 555);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1031, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.CausesValidation = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1031, 530);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseDoubleClick);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGrid_RowPostPaint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看详情ToolStripMenuItem,
            this.导出选中列txtToolStripMenuItem,
            this.隐藏该列ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 92);
            // 
            // 查看详情ToolStripMenuItem
            // 
            this.查看详情ToolStripMenuItem.Name = "查看详情ToolStripMenuItem";
            this.查看详情ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.查看详情ToolStripMenuItem.Text = "查看详情";
            this.查看详情ToolStripMenuItem.Click += new System.EventHandler(this.查看详情ToolStripMenuItem_Click);
            // 
            // 导出选中列txtToolStripMenuItem
            // 
            this.导出选中列txtToolStripMenuItem.Name = "导出选中列txtToolStripMenuItem";
            this.导出选中列txtToolStripMenuItem.ShowShortcutKeys = false;
            this.导出选中列txtToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.导出选中列txtToolStripMenuItem.Text = "导出选中列（.txt）";
            this.导出选中列txtToolStripMenuItem.Click += new System.EventHandler(this.导出选中列txtToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.ts_Index,
            this.toolStripSeparator1,
            this.ts_btnSearch,
            this.toolStripSeparator4,
            this.ts_btnReset,
            this.toolStripSeparator2,
            this.ts_btnExcel,
            this.toolStripSeparator3,
            this.ts_ExcelCurrent,
            this.toolStripSeparator5,
            this.toolStripLabel1,
            this.ts_combox,
            this.ts_search_content});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1031, 25);
            this.toolStrip1.TabIndex = 9;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton1.Text = "索引：";
            // 
            // ts_Index
            // 
            this.ts_Index.Name = "ts_Index";
            this.ts_Index.Size = new System.Drawing.Size(150, 25);
            this.ts_Index.TextChanged += new System.EventHandler(this.ts_Index_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_btnSearch
            // 
            this.ts_btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("ts_btnSearch.Image")));
            this.ts_btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btnSearch.Name = "ts_btnSearch";
            this.ts_btnSearch.Size = new System.Drawing.Size(56, 22);
            this.ts_btnSearch.Text = "搜 索";
            this.ts_btnSearch.Click += new System.EventHandler(this.ts_btnSearch_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_btnReset
            // 
            this.ts_btnReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_btnReset.Image = ((System.Drawing.Image)(resources.GetObject("ts_btnReset.Image")));
            this.ts_btnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btnReset.Name = "ts_btnReset";
            this.ts_btnReset.Size = new System.Drawing.Size(40, 22);
            this.ts_btnReset.Text = "重 置";
            this.ts_btnReset.Click += new System.EventHandler(this.ts_btnReset_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_btnExcel
            // 
            this.ts_btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_btnExcel.Name = "ts_btnExcel";
            this.ts_btnExcel.Size = new System.Drawing.Size(113, 22);
            this.ts_btnExcel.Text = "导出所有(Excel)";
            this.ts_btnExcel.Click += new System.EventHandler(this.ts_btnExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ts_ExcelCurrent
            // 
            this.ts_ExcelCurrent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ts_ExcelCurrent.Image = ((System.Drawing.Image)(resources.GetObject("ts_ExcelCurrent.Image")));
            this.ts_ExcelCurrent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_ExcelCurrent.Name = "ts_ExcelCurrent";
            this.ts_ExcelCurrent.Size = new System.Drawing.Size(84, 22);
            this.ts_ExcelCurrent.Text = "导出当前结果";
            this.ts_ExcelCurrent.Click += new System.EventHandler(this.ts_ExcelCurrent_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel1.Text = "Query：";
            // 
            // ts_combox
            // 
            this.ts_combox.Name = "ts_combox";
            this.ts_combox.Size = new System.Drawing.Size(121, 25);
            // 
            // ts_search_content
            // 
            this.ts_search_content.Name = "ts_search_content";
            this.ts_search_content.Size = new System.Drawing.Size(300, 25);
            this.ts_search_content.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ts_search_content_KeyPress);
            // 
            // 隐藏该列ToolStripMenuItem
            // 
            this.隐藏该列ToolStripMenuItem.Name = "隐藏该列ToolStripMenuItem";
            this.隐藏该列ToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.隐藏该列ToolStripMenuItem.Text = "隐藏选中列";
            this.隐藏该列ToolStripMenuItem.Click += new System.EventHandler(this.隐藏该列ToolStripMenuItem_Click);
            // 
            // CollectionViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 577);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MinimizeBox = false;
            this.Name = "CollectionViewMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "泛型数据可视化 v1.0 - (索引列可忽略，调试需要)";
            this.Load += new System.EventHandler(this.CollectionView_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查看详情ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripButton1;
        private System.Windows.Forms.ToolStripTextBox ts_Index;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ts_btnSearch;
        private System.Windows.Forms.ToolStripButton ts_btnReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ts_btnExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ts_ExcelCurrent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox ts_search_content;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 导出选中列txtToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox ts_combox;
        private System.Windows.Forms.ToolStripMenuItem 隐藏该列ToolStripMenuItem;
    }
}