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
    public static class LogHelper
    {
        /// <summary>
        ///  写日志
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <param name="msg">内容</param>
        /// <param name="ex">异常</param>
        /// <param name="fileName">文件名，默认自动生成</param>
        private static void WriteLog(string typeName, string msg, Exception ex, string fileName = null)
        {

            string filefullName = fileName.IsNullOrWhiteSpace() ?
                 Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format(@"Log\{0}\{1}\{2}.{3}", DateTime.Now.ToString("yyyy-MM"), typeName, DateTime.Now.ToString("yyyy-MM-dd"), "txt"))
                 : fileName;

            string folderName = Path.GetDirectoryName(filefullName);
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            if (ex != null)
            {
                msg += ex.Message + ", Exception=>" + ex.StackTrace;

                if (ex.InnerException != null)
                {
                    msg += ex.InnerException.Message + ", InnerException=>" + ex.InnerException.StackTrace;
                }
            }


            try
            {
                using (FileStream fs = new FileStream(filefullName, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                    {
                        sw.WriteLine(string.Format("[{0} {1}]: {2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), typeName, msg));
                        sw.WriteLine("---------------------------------------------------------");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        /// <summary>
        ///  写日志
        /// </summary>
        /// <param name="msg">内容</param>
        /// <param name="ex">异常</param>
        /// <param name="fileName">文件名，默认自动生成</param>
        private static void InfoLog(string msg, Exception ex, string fileName = null)
        {
            WriteLog("INFO", msg, ex, fileName);
        }

        /// <summary>
        ///  写日志
        /// </summary>
        /// <param name="msg">内容</param>
        /// <param name="fileName">文件名，默认自动生成</param>
        public static void InfoLog(string msg, string fileName = null)
        {
            InfoLog(msg, null, fileName);

        }


        /// <summary>
        ///  错误异常
        /// </summary>
        public static void ErrorLog(string msg, Exception ex, string fileName = null)
        {
            WriteLog("ERROR", msg, ex, fileName);
        }

        /// <summary>
        ///  错误异常
        /// </summary>
        public static void ErrorLog(string msg, string fileName = null)
        {
            WriteLog("ERROR", msg, null, fileName);
        }


        /// <summary>
        ///  读取文件内容
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string ReadContent(string fileName)
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
