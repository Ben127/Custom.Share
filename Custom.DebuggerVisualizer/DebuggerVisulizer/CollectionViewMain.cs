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
    public partial class CollectionViewMain : Form
    {
        public CollectionViewMain()
        {
            InitializeComponent();
        }

        private int total = 0;
        private DataTable dataTable;
        private DataTable dataTableQuery;
        public CollectionViewMain(DataTable dataTable)
            : this()
        {
            this.dataTable = dataTable;
            this.total = this.dataTable.Rows.Count;
        }

        public CollectionViewMain(object o)
            : this()
        {

        }


        public class ColumnName
        {
            public int Index { get; set; }
            public string Name { get; set; }
        }

        private List<ColumnName> _ColumnNames = new List<ColumnName>();

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

                _ColumnNames.Clear();
                _ColumnNames.Add(new ColumnName { Index = 0, Name = "-=查询某列=-" });
                int current = 1;

                foreach (DataGridViewColumn v in columns)
                {
                    _ColumnNames.Add(new ColumnName() { Index = current++, Name = v.Name });
                    v.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                ts_combox.ComboBox.DataSource = _ColumnNames;
                ts_combox.ComboBox.ValueMember = "Name";
                ts_combox.ComboBox.DisplayMember = "Name";

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


        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnExpertAll_Click(object sender, EventArgs e)
        {

        }


        private void btnExportCurrent_Click(object sender, EventArgs e)
        {

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



        private void search_index_TextChanged(object sender, EventArgs e)
        {

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
                CollectionViewMainDetail view = new CollectionViewMainDetail(value);
                view.ShowDialog();
            }

        }

        string pattern = @".*?(\d+).*?";

        private void ts_Index_TextChanged(object sender, EventArgs e)
        {
            string value = ts_Index.Text;
            Regex regex = new Regex(pattern, RegexOptions.Singleline);

            if (regex.IsMatch(value))
            {
                string newValue = regex.Replace(value, "$1");
                ts_Index.Text = newValue;
            }
            else
            {
                ts_Index.Text = "";
            }
        }

        private void ts_btnSearch_Click(object sender, EventArgs e)
        {
            bool searchSuccess = false;
            dataTableQuery = null;
            dataTableQuery = dataTable.Clone();

            if (!string.IsNullOrEmpty(ts_Index.Text))
            {
                searchSuccess = true;
                //
                int rowId = -1;
                if (int.TryParse(ts_Index.Text, out rowId) && rowId >= 0 && rowId < total)
                {
                    var tr = this.dataTable.Rows[rowId];
                    dataTableQuery.ImportRow(tr);
                }

            }
            else if (!string.IsNullOrEmpty(ts_search_content.Text))
            {


                // 查询
                string query = "";
                if (ts_combox.ComboBox.SelectedIndex > 0)
                {
                    query += ts_combox.ComboBox.SelectedValue + " ";
                }

                if (!string.IsNullOrEmpty(ts_search_content.Text.Trim()))
                {
                    query += ts_search_content.Text.Trim();
                }
                else
                {
                    query = "";
                }

                searchSuccess = true;

                try
                {
                    var trs = this.dataTable.Select(query);
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

        private void ts_btnReset_Click(object sender, EventArgs e)
        {
            this.ts_Index.Text = "";
            this.ts_search_content.Text = "";
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.dataTable;
            AppendLog("总计：" + this.total.ToString() + " 条");
        }

        private void ts_btnExcel_Click(object sender, EventArgs e)
        {
            Expert(this.dataTable);
        }

        private void ts_ExcelCurrent_Click(object sender, EventArgs e)
        {
            Expert(GetDgvToTable(this.dataGridView1, true));
        }

        private DataTable GetDgvToTable(DataGridView dgv, bool hiddenVisible = true)
        {
            DataTable dt = new DataTable();

            var columns = dgv.Columns.Cast<DataGridViewColumn>().Where(p => hiddenVisible && p.Visible).ToList();
            var columnsName = columns.Select(p => p.Name).ToList();
            foreach (var v in columns)
            {
                dt.Columns.Add(v.Name);
            }

            int rowIndex = 0;
            foreach (DataGridViewRow item in dgv.Rows)
            {
                DataRow dr = dt.NewRow();
                foreach (DataGridViewColumn c in dgv.Columns)
                {
                    if (columnsName.Contains(c.Name))
                    {
                        dr[c.Name] = Convert.ToString(item.Cells[c.Name].Value);
                    }

                }
                dt.Rows.Add(dr);

                rowIndex++;
            }

            return dt;
        }

        private void 导出选中列txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = (SaveFileDialog)null;
            try
            {
                var cell = this.dataGridView1.CurrentCell;
                if (cell != null)
                {
                    int columneIndex = cell.ColumnIndex;
                    string columneName = this.dataGridView1.Columns[columneIndex].Name;

                    SaveFileDialog saveFileDialog2 = new SaveFileDialog();
                    saveFileDialog2.Filter = "txt文件(*.txt)|*.txt";
                    saveFileDialog2.FileName = "调试器导出列_" + columneName + "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                    saveFileDialog1 = saveFileDialog2;
                    if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                        return;


                    var result = this.dataGridView1.Rows.Cast<DataGridViewRow>().AsEnumerable()
                                         .Select(p => p.Cells[columneName])
                                         .Select(p => p.Value.ToString())
                                         .ToList();
                    string content = string.Join("\r\n", result);
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, content);
                    MessageBox.Show("导出成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }


            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("导出失败!" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void ts_search_content_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ts_btnSearch_Click(null, null);
            }

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.dataGridView1.AutoSizeColumnsMode = this.dataGridView1.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill ? DataGridViewAutoSizeColumnsMode.None : DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void 隐藏该列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cells = this.dataGridView1.SelectedCells;
            if (cells.Count > 0)
            {
                int columnIndex = cells[0].ColumnIndex;
                this.dataGridView1.Columns[columnIndex].Visible = false;

            }
        }






    }
}
