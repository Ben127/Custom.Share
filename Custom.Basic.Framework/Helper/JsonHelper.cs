using Custom.Basic.Framework.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Helper
{
    /// <summary>
    /// JsonHelper
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// 序列化object对象。
        /// </summary>
        /// <param name="value">序列化的值。</param>
        /// <param name="isWriteDisplayName">是否输出DisplayName属性的值。</param>
        /// <returns>json字符串。</returns>
        public static string SerializeObject(object value, bool isWriteDisplayName = false)
        {
            return SerializeObject(value, null, null, isWriteDisplayName);
        }

        /// <summary>
        /// 序列化包含指定属性的值。
        /// </summary>
        /// <param name="value">序列化的值。</param>
        /// <param name="include">允许序列化的属性名称数组。</param>
        /// <param name="isWriteDisplayName">是否输出DisplayName属性的值。</param>
        /// <returns>json字符串。</returns>
        public static string SerializeIncludeProperty(object value, string[] include, bool isWriteDisplayName = false)
        {
            return SerializeObject(value, include, null, isWriteDisplayName);
        }

        /// <summary>
        /// 序列化不包含指定属性的值。
        /// </summary>
        /// <param name="value">序列化的值。</param>
        /// <param name="exclude">不允许序列化的属性名称数组。</param>
        /// <param name="isWriteDisplayName">是否输出DisplayName属性的值。</param>
        /// <returns>json字符串。</returns>
        public static string SerializeExcludeProperty(object value, string[] exclude, bool isWriteDisplayName = false)
        {
            return SerializeObject(value, null, exclude, isWriteDisplayName);
        }

        /// <summary>
        /// 序列化不包含指定属性的值。
        /// </summary>
        /// <param name="value">序列化的值。</param>
        /// <param name="include">允许序列化的属性名称数组。</param>
        /// <param name="exclude">不允许序列化的属性名称数组。</param>
        /// <param name="isWriteDisplayName">是否输出DisplayName属性的值。</param>
        /// <returns>json字符串。</returns>
        public static string SerializeObject(object value, string[] include, string[] exclude, bool isWriteDisplayName = false)
        {
            return JsonConvert.SerializeObject(
                value,
                new JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-dd HH:mm:ss",
                    ContractResolver = new PropertySerializeResolver(include, exclude, isWriteDisplayName),
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    NullValueHandling = NullValueHandling.Include
                });
        }


        /// <summary>
        /// 反序列化
        /// </summary>
        public static T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Include
            });
        }


    }
}
