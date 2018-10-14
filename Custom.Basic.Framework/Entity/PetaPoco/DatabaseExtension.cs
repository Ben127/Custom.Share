using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Entity.PetaPoco
{
    /// <summary>
    /// Database 扩展 添加批量添加
    /// </summary>
    public partial class Database
    {
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <typeparam name="T">泛型模型</typeparam>
        /// <param name="tableName">表名</param>
        /// <param name="datas">数据</param>
        /// <returns>返回是否添加成功</returns>
        public bool BulkInsert<T>(string tableName, List<T> datas)
        {
            Type type = typeof(T);
            Tuple<DataTable, string[]> tule = batchExecData(datas);
            return SqlBulkInsert(tule.Item1, tableName, tule.Item2);

        }

        /// <summary>
        /// 实体处理转换成dataTable
        /// </summary>
        /// <param name="datas">数据源</param>
        /// <returns></returns>
        private Tuple<DataTable, string[]> batchExecData<T>(List<T> datas)
        {
            DataTable dt = new DataTable();
            List<string> list = new List<string>();
            foreach (T entity in datas)
            {
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo column in entity.GetType().GetProperties())
                {
                    if (!dt.Columns.Contains(column.Name))
                    {
                        dt.Columns.Add(column.Name);
                        list.Add(column.Name);
                    }
                    object value = column.GetValue(entity, null);
                    if (value != null)
                    {
                        dr[column.Name] = value;
                    }
                }
                dt.Rows.Add(dr);
            }
            return new Tuple<DataTable, string[]>(dt, list.ToArray());
        }

        /// <summary>
        /// DataTale整张表数据插入数据
        /// </summary>
        /// <param name="dt">要插入的table数据</param>
        /// <param name="tableName">目标数据表名</param>
        /// <param name="fieldName">必须提供所有的字段</param>
        /// <returns>返回成功，或者失败 true  or false</returns>
        private bool SqlBulkInsert(DataTable dt, string tableName, string[] fieldName)
        {
            try
            {
                OpenSharedConnection();
                using (SqlBulkCopy bulk = new SqlBulkCopy(this.ConnectionString))
                {
                    try
                    {
                        //when the table data handle done
                        bulk.DestinationTableName = tableName;
                        foreach (string field in fieldName)
                        {
                            bulk.ColumnMappings.Add(field, field);
                        }
                        bulk.WriteToServer(dt);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        bulk.Close();
                    }
                }
            }
            finally
            {
                CloseSharedConnection();
            }
        }



    }
}
