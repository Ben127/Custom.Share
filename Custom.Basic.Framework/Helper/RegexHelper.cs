using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// RegexHelper
    /// </summary>
    public static class RegexHelper
    {
        /// <summary>
        ///  正则替换
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="input">需替换内容</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="replacement">替换内容</param>
        /// <param name="regexOptions">正则表达式选项</param>
        public static string RegexReplace(this string str, string pattern, string replacement, RegexOptions regexOptions)
        {
            if (str.IsNullOrWhiteSpace())
                return str;

            string result = Regex.Replace(str, pattern, replacement, regexOptions);
            return result;
        }

        /// <summary>
        /// 正则替换
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="input">字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="replacement">替换内容</param>
        /// <returns></returns>
        public static string RegexReplace(this string str, string pattern, string replacement)
        {
            return RegexReplace(str, pattern, replacement, RegexOptions.IgnoreCase);
        }


        /// <summary>
        ///  正则匹配
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="input">匹配内容</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="regexOptions">正则表达式选项</param>
        /// <returns></returns>
        public static MatchCollection Mathes(this string str, string input, string pattern, RegexOptions regexOptions)
        {
            return Regex.Matches(input, pattern, regexOptions);
        }

        /// <summary>
        ///  正则匹配
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="input">匹配内容</param>
        /// <param name="pattern">正则表达式</param>
        /// <returns></returns>
        public static MatchCollection Mathes(this string str, string input, string pattern)
        {
            return Mathes(str, input, pattern, RegexOptions.IgnoreCase);
        }


        /// <summary>
        ///  正则是否匹配
        /// </summary>
        /// <param name="input">匹配内容</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="options">正则表达式选项</param>
        /// <returns></returns>
        public static bool IsMatch(string input, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(input, pattern, options);
        }

        /// <summary>
        ///  正则是否匹配
        /// </summary>
        /// <param name="input">匹配内容</param>
        /// <param name="pattern">正则表达式</param>
        /// <returns></returns>
        public static bool IsMatch(string input, string pattern)
        {
            return IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }


    }
}
