using System;
using System.Collections;
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
    public partial class CollectionView : Form
    {
        public CollectionView()
        {
            InitializeComponent();
        }

        private ICollection ICollection;
        public CollectionView(ICollection _ICollection)
            : this()
        {
            ICollection = _ICollection;
        }

        private void CollectionView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dataGrid.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dataGrid.RowHeadersDefaultCellStyle.Font, rectangle, dataGrid.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private Dictionary<string, int> cacheDataTable = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);


        private void SetDataTable(string name)
        {
            if (!cacheDataTable.ContainsKey(name))
            {
                cacheDataTable.Add(name, 0);
            }
            else
            {
                var count = cacheDataTable[name];
                cacheDataTable[name] = (count += 1);
                var newName = GetKeyName(name, count);
                SetDataTable(newName);
            }
        }

        private string GetKeyName(string name, int count)
        {
            return string.Format("{0}{1}", name, count > 0 ? count.ToString() : "");
        }

        private void LoadData()
        {
            Type type = ICollection.GetType();
            bool isGenericType = type.IsGenericType;
            if (!isGenericType)
            {
                return;
            }

            var memberType = type.GenericTypeArguments[0];
            var pis = memberType.GetProperties();

            DataTable dt = new DataTable();
            dt.TableName = memberType.Name;
            SetDataTable(dt.TableName);

            foreach (var p in pis)
            {
                dt.Columns.Add(p.Name, p.PropertyType);
            }

            int rowIndex = 0;
            foreach (var item in ICollection)
            {
                var dr = dt.NewRow();
                foreach (var v in pis)
                {
                    var val = v.GetValue(item, null);
                    dr[v.Name] = val;
                }
                dt.Rows.Add(dr);
                rowIndex++;
            }

            dataGrid.DataSource = null;
            dataGrid.DataSource = dt;
            Log("加载数据>>>> total：" + dt.Rows.Count);

        }


        private void Log(string msg)
        {
            string text = AppendLog(msg);
            toolLog.Text = text;
        }

        private string AppendLog(string msg)
        {
            return string.Format("[{0}]：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg);
        }


    }
}
