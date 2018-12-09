using OfficeOpenXml;
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
        /// <param name="password">密码</param>
        public static void Export<T>(List<T> datas, string excelName, string password = "")
        {
            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("sheet");
                ws.Cells["A1"].LoadFromCollection(datas, true, TableStyles.Light12);

                p.SaveAs(new FileInfo(excelName), password);
            }

        }

        /// <summary>
        ///  DataTable 导出Excel
        /// </summary>
        /// <param name="datas">数据</param>
        /// <param name="excelName">Excel文件名</param>
        /// <param name="password">密码</param>
        public static void Export(DataTable datas, string excelName, string password = "")
        {
            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("sheet");
                ws.Cells["A1"].LoadFromDataTable(datas, true);

                p.SaveAs(new FileInfo(excelName), password);
            }

        }





    }
}
