using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// FileHelper
    /// </summary>
    public static class FileHelper
    {

        public static void WriteLog(string msg, string fileName = "log.txt")
        {

            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        sw.WriteLine(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        ///  写入日志，含默认模板
        ///             
        ///                 ***************************************************************************
        ///                 
        ///                 
        ///         
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="fileName"></param>
        public static void InfoLog(string msg, string fileName)
        {

        }


        /// <summary>
        ///  读取文件内容
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReadFileContent(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
