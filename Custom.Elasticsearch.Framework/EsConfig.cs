using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Elasticsearch.Framework
{
    /// <summary>
    ///  Es 配置
    /// </summary>
    internal class EsConfig
    {
        /// <summary>
        ///  服务节点
        /// </summary>
        internal static string Nodes = ConfigurationManager.AppSettings["elasticsearch.nodes"];

        /// <summary>
        /// 配置文件分割符
        /// </summary>
        internal static char[] SplitChar = new char[] { ' ', ',', ';', '，', '；', '|' };

        /// <summary>
        ///  是否调试模式
        /// </summary>
        internal static string DebuggerMode = ConfigurationManager.AppSettings["elasticsearch.debuggermode"];
    }
}
