﻿using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Package.Excel
{
    /// <summary>
    /// Epplus Excel 导出
    /// </summary>
    public class ExcelEpplusManager
    {
        /// <summary>
        /// 泛型列表导出Excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas">数据</param>
        /// <param name="excelName">Excel文件名</param>
        public static void Export<T>(List<T> datas, string excelName, bool printHeader = true, TableStyles tableStyle = TableStyles.Light12)
        {
            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("sheet");
                ws.Cells["A1"].LoadFromCollection(datas, printHeader, tableStyle);

                p.SaveAs(new FileInfo(excelName));
            }

        }

        public static void Export(string excelName, Action<ExcelPackage> excelFunc)
        {
            using (var p = new ExcelPackage())
            {
                excelFunc(p);
                p.SaveAs(new FileInfo(excelName));
            }

        }

        /// <summary>
        /// 字典列表导出Excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas">数据</param>
        /// <param name="excelName">Excel文件名</param>
        /// <param name="password">密码</param>
        public static void Export<T>(Dictionary<string, List<T>> dataDicts, string excelName)
        {
            using (var p = new ExcelPackage())
            {
                foreach (var v in dataDicts)
                {
                    var ws = p.Workbook.Worksheets.Add(v.Key);

                    // 
                    ws.Cells["A2"].LoadFromText(v.Key);
                    int left = 2;
                    int right = v.Value.Count;
                    if (left > right)
                    {
                        right = left;
                    }

                    ws.Cells[string.Format("A2:A{0}", right)].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    ws.Cells[string.Format("A2:A{0}", right)].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    ws.Cells[string.Format("A2:A{0}", right)].Merge = true;

                    ws.Cells["B1"].LoadFromCollection(v.Value, false, TableStyles.Light12);
                }

                p.SaveAs(new FileInfo(excelName));
            }

        }


        /// <summary>
        ///  DataTable 导出Excel
        /// </summary>
        /// <param name="datas">数据</param>
        /// <param name="excelName">Excel文件名</param>
        public static void Export(DataTable datas, string excelName, bool printHeader = true)
        {
            using (var p = new ExcelPackage())
            {
                var dict = GetSplitDataTable(datas);
                foreach (var item in dict)
                {
                    var ws = p.Workbook.Worksheets.Add("sheet" + item.Key);
                    ws.Cells["A1"].LoadFromDataTable(item.Value, true, TableStyles.Light12);
                }

                p.SaveAs(new FileInfo(excelName));
            }

        }


        private static Dictionary<int, DataTable> GetSplitDataTable(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return new Dictionary<int, DataTable>();

            int excel2007Total = 1048576 - 1;

            Dictionary<int, DataTable> result = new Dictionary<int, DataTable>();

            var rows = dt.Rows;
            var columns = dt.Columns;

            List<DataRow> drs = new List<DataRow>();
            foreach (DataRow dr in rows)
            {
                drs.Add(dr);
            }

            //
            var dict = SplitDict(drs, excel2007Total);
            foreach (var v in dict)
            {
                DataTable table = new DataTable();
                foreach (DataColumn col in columns)
                {
                    table.Columns.Add(col.ColumnName, col.DataType);
                }

                foreach (DataRow d in v.Value)
                {
                    table.ImportRow(d);
                }

                result.Add(v.Key, table);
            }


            return result;
        }

        private static Dictionary<int, List<T>> SplitDict<T>(List<T> data, int sliceSize)
        {
            if (data == null || data.Count == 0)
                return new Dictionary<int, List<T>> { { 1, data } };

            int take = sliceSize;
            int page = (int)Math.Ceiling(data.Count / (decimal)take);


            Dictionary<int, List<T>> result = new Dictionary<int, List<T>>();
            for (int i = 0; i < page; i++)
            {
                var _data = data.Skip(i * take).Take(take).ToList();
                result.Add(i + 1, _data);
            }

            return result;
        }



    }
}
