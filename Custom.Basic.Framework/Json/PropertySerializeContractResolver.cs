using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Json
{
    /// <summary>
    /// 属性序列化器。
    /// </summary>
    public class PropertySerializeResolver : DefaultContractResolver
    {
        /// <summary>
        /// 指定允许序列化的属性名称数组、不允许序列化的属性名称数组，实例化PropertySerializeContractResolver类的新实例。
        /// </summary>
        /// <param name="include">允许序列化的属性名称数组。</param>
        /// <param name="exclude">不允许序列化的属性名称数组。</param>
        /// <param name="isWriteDisplayName">是否输出DisplayName属性的值。</param>
        public PropertySerializeResolver(string[] include = null, string[] exclude = null, bool isWriteDisplayName = false)
        {
            this.Include = include;
            this.Exclude = exclude;
            this.IsWriteDisplayName = isWriteDisplayName;
        }

        /// <summary>
        /// 获取或设置允许序列化的属性名称数组。
        /// </summary>
        public string[] Include { get; set; }

        /// <summary>
        /// 获取或设置不允许序列化的属性名称数组。
        /// </summary>
        public string[] Exclude { get; set; }

        /// <summary>
        /// 是否输出DisplayName属性的值。
        /// </summary>
        public bool IsWriteDisplayName { get; set; }


    }
}