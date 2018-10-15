using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// DictionaryHelper
    /// </summary>
    public static class DictionaryHelper
    {
        /// <summary>
        ///  获取字典值
        /// </summary>
        /// <typeparam name="K">键类型</typeparam>
        /// <typeparam name="V">值类型</typeparam>
        /// <param name="dictionary">字典</param>
        /// <param name="keyName">键名</param>
        /// <param name="defaultValue">如果没有值的指定默认值</param>
        /// <returns>返回键值</returns>
        public static V Get<K, V>(this IDictionary<K, V> dictionary, K keyName, V defaultValue)
        {
            if (dictionary.ContainsKey(keyName))
            {
                V value = defaultValue;
                value = dictionary.TryGetValue(keyName, out value) ? value : defaultValue;

                return value;
            }

            return default(V);
        }

        /// <summary>
        ///  以字符串为键的字典
        /// </summary>
        /// <typeparam name="T">value值类型</typeparam>
        /// <param name="dictionary">字典</param>
        /// <param name="keyName">键名</param>
        /// <returns>返回键值</returns>
        public static T Get<T>(this IDictionary<string, T> dictionary, string keyName)
        {
            return Get<string, T>(dictionary, keyName, default(T));
        }

        /// <summary>
        /// 以 long 为键的字典
        /// </summary>
        /// <typeparam name="T">value值类型</typeparam>
        /// <param name="dictionary">字典</param>
        /// <param name="keyName">键名</param>
        /// <returns>返回键值</returns>
        public static T Get<T>(this IDictionary<long, T> dictionary, long keyName)
        {
            return Get<long, T>(dictionary, keyName, default(T));
        }


        /// <summary>
        /// 以 int 为键的字典
        /// </summary>
        /// <typeparam name="T">value值类型</typeparam>
        /// <param name="dictionary">字典</param>
        /// <param name="keyName">键名</param>
        /// <returns>返回键值</returns>
        public static T Get<T>(this IDictionary<int, T> dictionary, int keyName)
        {
            return Get<int, T>(dictionary, keyName, default(T));
        }


    }
}
