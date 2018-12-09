using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Package.Web
{
    /// <summary>
    /// xpath html 操作
    /// </summary>
    public class HtmlAgPackXpathManager
    {
        /// <summary>
        ///  从文件获取文档节点内容
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static HtmlDocument GetFileDocument(string filepath)
        {
            var doc = new HtmlDocument();
            doc.Load(filepath);

            return doc;
        }

        /// <summary>
        /// 从字符串获取文档节点内容
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static HtmlDocument GetStringDocument(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            return doc;
        }

        /// <summary>
        ///  远程加载Url获取文档节点内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static HtmlDocument GetWebDocument(string url)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);

            return doc;
        }

    }
}
