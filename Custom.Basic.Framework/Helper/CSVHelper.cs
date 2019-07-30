using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// CSVHelper
    /// </summary>
    public class CSVHelper
    {
        public static List<T> Read<T>(string fullFileName, bool hasHeader = true)
        {
            using (var reader = new StreamReader(fullFileName))
            {
                using (var csv = new CsvHelper.CsvReader(reader))
                {
                    csv.Configuration.HasHeaderRecord = hasHeader;
                    var result = csv.GetRecords<T>().ToList();

                    return result;
                }

            }

        }

    }
}
