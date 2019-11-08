using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Config
{
    /// <summary>
    /// CustomRollingFileAppender
    /// </summary>
    public class CustomRollingFileAppender : log4net.Appender.RollingFileAppender
    {
        /// <summary>
        /// 根据日志配置文件激活日志信息。
        /// </summary>
        public override void ActivateOptions()
        {
            base.ActivateOptions();
            this.DeleteEmptyLogFile(this.File);
        }

        /// <summary>
        /// 关闭日志记录器。
        /// </summary>
        protected override void OnClose()
        {
            var logFile = this.File;
            base.OnClose();
            this.DeleteEmptyLogFile(logFile);
        }

        /// <summary>
        /// 删除空白日志文件。
        /// </summary>
        /// <param name="logFile">文件名。</param>
        private void DeleteEmptyLogFile(string logFile)
        {
            var fileInfo = new FileInfo(logFile);
            if (!fileInfo.Exists || fileInfo.Length > 0)
            {
                return;
            }

            try
            {
                System.IO.File.Delete(fileInfo.FullName);


            }
            catch (Exception ex)
            {

            }
        }
    }
}
