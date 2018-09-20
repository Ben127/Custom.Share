using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Custom.SqlClr.RegexEx
{
    /// <summary>
    ///  SQL Server 扩展
    /// </summary>
    public class RegexExtend
    {
        /// <summary>  
        /// 正则匹配  
        /// </summary>  
        /// <param name="regex">正则表达式</param>  
        /// <param name="input">文本</param>  
        /// <returns></returns>  
        [Microsoft.SqlServer.Server.SqlFunction]
        public static string Match(string regex, string input)
        {
            return string.IsNullOrEmpty(input) ? "" : new Regex(regex, RegexOptions.IgnoreCase).Match(input).Value;
        }

        /// <summary>  
        /// 正则替换  
        /// </summary>  
        /// <param name="regex">正则表达式</param>  
        /// <param name="input">文本</param>  
        /// <param name="replace">要替换的目标</param>  
        /// <returns></returns>  
        [Microsoft.SqlServer.Server.SqlFunction]
        public static string Replace(string regex, string input, string replace)
        {
            return string.IsNullOrEmpty(input) ? "" : new Regex(regex, RegexOptions.IgnoreCase).Replace(input, replace);
        }

        /// <summary>  
        /// 正则校验  
        /// </summary>  
        /// <param name="regex">正则表达式</param>  
        /// <param name="input">文本</param>  
        /// <returns></returns>  
        [Microsoft.SqlServer.Server.SqlFunction]
        public static bool IsMatch(string regex, string input)
        {
            return !string.IsNullOrEmpty(input) && new Regex(regex, RegexOptions.IgnoreCase).IsMatch(input);
        }

    }
}
