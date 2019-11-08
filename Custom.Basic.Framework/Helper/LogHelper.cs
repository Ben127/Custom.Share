using log4net;
using log4net.Appender;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// logHelper
    /// </summary>
    public abstract class LogHelper : LogBaseHelper
    {
        private static readonly ILog log;

        static LogHelper()
        {
            //XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Config/Log4net.config"));

            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }


        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void Error(string msg, Exception ex = null)
        {
            log.Error(msg, ex);
        }

        /// <summary>
        /// 正常日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void Info(string msg, Exception ex = null)
        {
            log.Info(msg, ex);
        }

        /// <summary>
        /// 警告日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void Warning(string msg, Exception ex = null)
        {
            log.Warn(msg, ex);
        }

        /// <summary>
        /// Debug 日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void Debug(string msg, Exception ex = null)
        {
            log.Debug(msg, ex);
        }

    }


    /// <summary>
    /// log4net 基类
    /// </summary>
    public abstract class LogBaseHelper : FileAppender.MinimalLock
    {

        public override Stream AcquireLock()
        {
            if (CurrentAppender.Threshold == log4net.Core.Level.Off)
                return null;

            return base.AcquireLock();
        }



    }

}
