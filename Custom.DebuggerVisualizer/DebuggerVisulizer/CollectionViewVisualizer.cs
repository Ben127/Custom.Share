using Custom.DebuggerVisualizer.V12.DebuggerVisulizer;
using CYQ.Data.Table;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(List<>), Description = "IList Visualizer v1.0")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(Dictionary<,>), Description = "IList Visualizer v1.0")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(ArrayList), Description = "IList Visualizer v1.0")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(ReadOnlyCollectionBase), Description = "IList Visualizer v1.0")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(Hashtable), Description = "IList Visualizer v1.0")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(Queue), Description = "IList Visualizer v1.0")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(SortedList), Description = "IList Visualizer v1.0")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(Stack), Description = "IList Visualizer v1.0")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(ListDictionary), Description = "IList Visualizer v1.0")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(NameObjectCollectionBase), Description = "IList Visualizer v1.0")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(LinkedList<>), Description = "IList Visualizer v1.0")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(Dictionary<,>.KeyCollection), Description = "IList Visualizer v1.0")]
[assembly: System.Diagnostics.DebuggerVisualizer(typeof(Custom.DebuggerVisualizer.V12.DebuggerVisulizer.CollectionViewVisualizer), typeof(CollectionObjectSource), Target = typeof(Dictionary<,>.ValueCollection), Description = "IList Visualizer v1.0")]

namespace Custom.DebuggerVisualizer.V12.DebuggerVisulizer
{
    /// <summary>
    /// 集合调试器
    /// </summary>
    public class CollectionViewVisualizer : BaseDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            MDataTable dt = objectProvider.GetObject() as DataTable;
            if (dt != null)
            {
                try
                {
                    BindTable(windowService, dt);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }

        }


        private void BindTable(IDialogVisualizerService windowService, MDataTable dt)
        {
            if (dt == null) { return; }
            //if (dt.Rows.Count > 200)
            //{
            //    dt = dt.Select(200, null);
            //}

            //插入行号
            MCellStruct ms = new MCellStruct("序号", System.Data.SqlDbType.Int);
            dt.Columns.Insert(0, ms);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0].Value = i + 1;
            }

            CollectionView form = new CollectionView(dt.ToDataTable());
            windowService.ShowDialog(form);
        }



        /// <summary>
        /// DEBUG 使用
        /// </summary>
        /// <param name="objectToVisualize"></param>
        public static void TestShowVisualizer(object objectToVisualize)
        {
            var visualizerHost = new VisualizerDevelopmentHost(
                objectToVisualize,
                typeof(CollectionViewVisualizer),
                typeof(CollectionObjectSource));
            visualizerHost.ShowVisualizer();
        }

    }


    /// <summary>
    /// 自定义数据源
    /// </summary>
    public class CollectionObjectSource : BaseVisualizerObjectSource
    {
        public override void GetData(object target, System.IO.Stream outgoingData)
        {
            MDataTable dt = null;
            #region 类型判断


            if (target is MDataTable)
            {
                dt = target as MDataTable;
            }
            else if (target is MDataRow)
            {
                dt = ((MDataRow)target).ToTable();
            }
            else if (target is MDataColumn)
            {
                dt = ((MDataColumn)target).ToTable();
            }
            else if (target is MDataRowCollection)
            {
                dt = target as MDataRowCollection;
            }
            else if (target is DataRow)
            {
                MDataRow row = target as DataRow;
                dt = row.ToTable();
            }
            else if (target is DataColumnCollection)
            {
                MDataColumn mdc = target as DataColumnCollection;
                dt = mdc.ToTable();
            }
            else if (target is DataRowCollection)
            {
                MDataRowCollection rows = target as DataRowCollection;
                dt = rows;
            }
            else if (target is NameObjectCollectionBase)
            {
                dt = MDataTable.CreateFrom(target as NameObjectCollectionBase);
            }
            else if (target is IEnumerable)
            {
                dt = MDataTable.CreateFrom(target as IEnumerable);
            }
            else
            {
                dt = MDataTable.CreateFrom(target);
                if (dt == null)
                {
                    MDataRow row = MDataRow.CreateFrom(target);
                    if (row != null)
                    {
                        dt = row.ToTable();
                    }
                }
            }
            #endregion
            dt = Format(dt);
            if (dt != null)
            {
                base.GetData(dt.ToDataTable(), outgoingData);
            }
            else
            {

                base.GetData(new DataTable("Empty Table"), outgoingData);
            }
        }
        private MDataTable Format(MDataTable dt)
        {
            if (dt != null && dt.Columns.Count > 0)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].SqlType == System.Data.SqlDbType.Variant)
                    {
                        for (int k = 0; k < dt.Rows.Count; k++)
                        {
                            if (!dt.Rows[k][i].IsNull)
                            {
                                dt.Rows[k][i].Value = dt.Rows[k][i].ToString();
                            }
                        }
                        dt.Columns[i].SqlType = System.Data.SqlDbType.NVarChar;//避开未序列化的对象。
                    }
                }
            }
            return dt;
        }

    }

}
