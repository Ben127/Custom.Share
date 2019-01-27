using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom.Basic.Framework.Package.Redis
{
    /// <summary>
    /// Redis 键Key 类型
    ///     五种类型  Hash List String ...
    /// </summary>
    public enum Redis_KeyType
    {
        /// <summary>
        /// 散列类型
        /// </summary>
        Hash,
        /// <summary>
        /// 列表类型
        /// </summary>
        List,
        /// <summary>
        /// 字符串类型
        /// </summary>
        String,
        /// <summary>
        /// 集合类型
        /// </summary>
        Set,
        /// <summary>
        ///  含权重的有序集合
        /// </summary>
        SortSet,
    }

    /// <summary>
    /// Redis 排序方式
    /// </summary>
    public enum Redis_Order
    {
        Ascending,
        Descending
    }


}
