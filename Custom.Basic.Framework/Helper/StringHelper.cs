using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// StringHelper
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 指示指定的字符串是 null 还是 System.String.Empty 字符串。
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }


        /// <summary>
        /// 串联集合的成员，其中在每个成员之间使用指定的分隔符。
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="values">泛型集合</param>
        /// <param name="separator">连接符</param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> values, string separator)
        {
            return string.Join<T>(separator, values);
        }

        /// <summary>
        /// 串联集合的成员，其中在每个成员之间使用指定的分隔符。
        /// </summary>
        /// <param name="values">泛型集合</param>
        /// <param name="separator">连接符</param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> values, string separator)
        {
            return Join<string>(values, separator);
        }


        /// <summary>
        /// 从此实例检索子字符串。 子字符串从指定的字符位置开始且具有指定的长度。
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="start">开始位置</param>
        /// <param name="length">长度</param>
        /// <param name="append">尾部追加</param>
        /// <returns></returns>
        public static string Substr(this string str, int start, int length, string append)
        {

            if (start >= length)
                return "";

            int _start = start, _length = 0;

            CharEnumerator ce = str.GetEnumerator();
            while (ce.MoveNext())
            {
                _start++;
                if (_start <= length)
                {
                    _length++;
                }
                else
                {
                    return str.Substring(start, _length);
                }

            }

            return str;
        }

        /// <summary>
        /// 从此实例检索子字符串。 子字符串从指定的字符位置开始且具有指定的长度。
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="start">开始位置</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string Substr(this string str, int start, int length)
        {
            return Substr(str, start, length, "");
        }

        /// <summary>
        /// 从此实例检索子字符串。 子字符串具有指定的长度。
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string Substr(this string str, int length)
        {
            return Substr(str, 0, length);
        }

    }
}
