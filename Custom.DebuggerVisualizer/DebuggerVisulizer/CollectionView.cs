using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    public partial class CollectionView : Form
    {
        public CollectionView()
        {
            InitializeComponent();
        }

        private int total = 0;
        private DataTable dataTable;
        private DataTable dataTableQuery;
        public CollectionView(DataTable dataTable)
            : this()
        {
            this.dataTable = dataTable;
            this.total = this.dataTable.Rows.Count;
        }

        public CollectionView(object o)
            : this()
        {

        }

        private void CollectionView_Load(object sender, EventArgs e)
        {
            if (this.dataTable != null)
            {
                //
                ////this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
                ////this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Transparent;
                //this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.dataGridView1.DataSource = this.dataTable;
                this.dataTableQuery = this.dataTable;

                var columns = this.dataGridView1.Columns;
                columns[0].Width = 80;

                foreach (DataGridViewColumn v in columns)
                {
                    v.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                Log("总计：" + this.total.ToString() + " 条");

            }
        }

        private void dataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGridView1.RowHeadersWidth - 15, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGridView1.RowHeadersDefaultCellStyle.Font, rectangle, dataGridView1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private Dictionary<string, int> cacheDataTable = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private void Log(string msg)
        {
            string text = AppendLog(msg);
            toolLog.Text = text;
        }

        private string AppendLog(string msg)
        {
            return string.Format("[{0}]：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool searchSuccess = false;
            dataTableQuery = null;
            dataTableQuery = dataTable.Clone();

            if (!string.IsNullOrEmpty(search_index.Text))
            {
                searchSuccess = true;
                //
                int rowId = -1;
                if (int.TryParse(search_index.Text, out rowId) && rowId >= 0 && rowId < total)
                {
                    var tr = this.dataTable.Rows[rowId];
                    dataTableQuery.ImportRow(tr);
                }

            }
            else if (!string.IsNullOrEmpty(search_content.Text))
            {
                searchSuccess = true;

                try
                {
                    var trs = this.dataTable.Select(search_content.Text);
                    foreach (var v in trs)
                    {
                        dataTableQuery.ImportRow(v);
                    }
                }
                catch (Exception ex)
                {
                    Log(ex.Message);
                    return;
                }
            }

            if (searchSuccess)
            {
                this.dataGridView1.DataSource = dataTableQuery;
                Log("总计：" + dataTableQuery.Rows.Count.ToString() + " 条");
            }
            else
            {
                this.dataGridView1.DataSource = dataTable;
                Log("总计：" + total.ToString() + " 条");
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.search_index.Text = "";
            this.search_content.Text = "";
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.dataTable;
            AppendLog("总计：" + this.total.ToString() + " 条");
        }

        private void btnExpertAll_Click(object sender, EventArgs e)
        {
            Expert(this.dataTable);
        }


        private void btnExportCurrent_Click(object sender, EventArgs e)
        {
            Expert(this.dataTableQuery);
        }

        private Thread InvokeThread = null;

        private void Expert(DataTable dt)
        {
            if (dt == null)
                return;


            InvokeThread = new Thread(new ThreadStart(() =>
           {
               SaveFileDialog sf = new SaveFileDialog();
               sf.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
               sf.FileName = string.Format("{0}_{1}.xlsx", "导出", DateTime.Now.ToString("yyyyMMdd"));
               if (sf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
               {
                   try
                   {
                       ExcelEpplus.Export(dt, sf.FileName);
                       MessageBox.Show("导出成功_" + sf.FileName);
                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message);
                   }

               }
           }));
            InvokeThread.IsBackground = true;
            InvokeThread.SetApartmentState(ApartmentState.STA);
            InvokeThread.Start();
            InvokeThread.Join();



        }

        string pattern = @".*?(\d+).*?";

        private void search_index_TextChanged(object sender, EventArgs e)
        {
            string value = search_index.Text;
            Regex regex = new Regex(pattern, RegexOptions.Singleline);

            if (regex.IsMatch(value))
            {
                string newValue = regex.Replace(value, "$1");
                search_index.Text = newValue;
            }
            else
            {
                search_index.Text = "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 查看详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cells = this.dataGridView1.SelectedCells;
            if (cells.Count > 0)
            {
                object obj = cells[0].Value;
                if (obj == null)
                {
                    return;
                }

                string value = obj.ToString();
                CollectionDetailView view = new CollectionDetailView(value);
                view.ShowDialog();
            }

        }






    }
}
