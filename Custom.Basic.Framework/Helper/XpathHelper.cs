using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// XPath 操作
    /// </summary>
    public class XpathHelper
    {

        /// <summary>
        /// 远程加载 并匹配 xpath
        /// </summary>
        /// <param name="url"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public static HtmlNodeCollection GetWebNodes(string url, string xpath, string encoding = null, Action<HtmlWeb> act = null)
        {
            var web = new HtmlWeb(); 
            web.OverrideEncoding = Encoding.GetEncoding(encoding ?? "utf-8");
            if (act != null)
            {
                act(web);
            }

            var doc = web.Load(url);

            return doc.DocumentNode.SelectNodes(xpath);
        }

        public static string GetWebString(string url, string xpath = null, string encoding = null, Action<HtmlWeb> act = null)
        {
            var web = new HtmlWeb();
            web.OverrideEncoding = Encoding.GetEncoding(encoding ?? "utf-8");
            if (act != null)
            {
                act(web);
            }
            var doc = web.Load(url);

            if (!string.IsNullOrEmpty(xpath))
                return doc.DocumentNode.SelectSingleNode(xpath).OuterHtml;

            return doc.DocumentNode.OuterHtml;
        }

        /// <summary>
        /// 字符串 并匹配 xpath
        /// </summary>
        /// <param name="input"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public static HtmlNodeCollection GetStringNodes(string input, string xpath)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(input);

            var nodes = doc.DocumentNode.SelectNodes(xpath);
            return nodes;
        }

        public static HtmlNode GetStringSingleNodes(string input, string xpath)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(input);

            var nodes = doc.DocumentNode.SelectSingleNode(xpath);
            return nodes;
        }

        /// <summary>
        /// 字符串匹配 xpath
        /// </summary>
        public static string GetStringByString(string input, string xpath)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(input);

            var node = doc.DocumentNode.SelectSingleNode(xpath);
            return node == null ? null : node.OuterHtml.Trim();
        }

        /// <summary>
        /// 字符串匹配 xpath 多次
        /// </summary>
        /// <param name="input"></param>
        /// <param name="xpaths"></param>
        /// <returns></returns>
        public static string GetStringByString(string input, params string[] xpaths)
        {

            foreach (var xpath in xpaths)
            {
                input = GetStringByString(input, xpath);
                if (input == null)
                {
                    break;
                }
            }

            return input;

        }

    }
}
