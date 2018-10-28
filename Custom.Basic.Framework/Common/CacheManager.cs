using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Common
{
    /// <summary>
    /// CacheManage
    /// </summary>
    public class CacheManager : ICache
    {

        private CacheManager()
        {

        }

        private static CacheManager Instance = new CacheManager();


        /// <summary>
        ///  缓存内容
        /// </summary>
        [DebuggerDisplay("当前缓存项： Count = {CacheView.Count}")]
        public static Dictionary<object, object> CacheView
        {
            get
            {
                return cacheDictionary;
            }
        }


        /// <summary>
        ///  缓存
        /// </summary>
        private static Dictionary<object, object> cacheDictionary = new Dictionary<object, object>();

        /// <summary>
        ///  清空缓存
        /// </summary>
        public static void ClearAll()
        {
            cacheDictionary.Clear();
        }


        /// <summary>
        ///  添加缓存
        /// </summary>
        /// <typeparam name="CacheKey">缓存值，必须唯一</typeparam>
        /// <typeparam name="Key">当前缓存列表 Key类型</typeparam>
        /// <typeparam name="Value">当前缓存列表 Value类型</typeparam>
        /// <param name="cacheKey">缓存值cacheKey</param>
        /// <param name="data">当前缓存列表</param>
        public static void Add<CacheKey, Key, Value>(CacheKey cacheKey, Dictionary<Key, Value> data)
        {
            if (!cacheDictionary.ContainsKey(cacheKey) && data != null && data.Count > 0)
            {
                cacheDictionary.Add(cacheKey, data);
                return;
            }

            throw new Exception("已存在的键值名称" + cacheKey + " 或键值不允许为空");
        }

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <typeparam name="CacheKey">缓存值，必须唯一</typeparam>
        /// <typeparam name="Key">当前缓存列表 Key类型</typeparam>
        /// <typeparam name="Value">当前缓存列表 Value类型</typeparam>
        /// <param name="cacheKey">缓存值cacheKey</param>
        /// <param name="key">当前缓存列表 Key 键</param>
        /// <returns></returns>
        public static Value Get<CacheKey, Key, Value>(CacheKey cachekey, Key key)
        {
            if (cacheDictionary.ContainsKey(cachekey))
            {
                Dictionary<Key, Value> dictionary = (Dictionary<Key, Value>)cacheDictionary[cachekey];
                if (dictionary.ContainsKey(key))
                {
                    return (Value)dictionary[key];
                }
            }

            return default(Value);
        }


        /// <summary>
        ///  检查是否存在该键值
        /// </summary>
        /// <typeparam name="CacheKey">缓存值，必须唯一</typeparam>
        /// <param name="cacheKey">缓存值cacheKey</param>
        /// <returns></returns>
        public static bool Exists<CacheKey>(CacheKey cacheKey)
        {
            return cacheDictionary.ContainsKey(cacheKey);
        }


        /// <summary>
        ///  移除缓存
        /// </summary>
        /// <typeparam name="CacheKey">缓存值，必须唯一</typeparam>
        /// <typeparam name="Key">当前缓存列表 Key类型</typeparam>
        /// <param name="cacheKey">缓存值cacheKey</param>
        /// <param name="key">当前缓存列表 Key 键</param>
        /// <returns></returns>
        public static bool Remove<CacheKey, Key, Value>(CacheKey cachekey, Key key)
        {
            if (cacheDictionary.ContainsKey(cachekey))
            {
                var cache = cacheDictionary[cachekey] as Dictionary<Key, Value>;
                if (cache != null && cache.ContainsKey(key))
                {
                    cache.Remove(key);
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        ///  移除缓存项
        /// </summary>
        /// <typeparam name="CacheKey">缓存项键名</typeparam>
        /// <param name="cachekey">缓存项键名</param>
        /// <returns></returns>
        public static bool Remove<CacheKey>(CacheKey cachekey)
        {
            if (cacheDictionary.ContainsKey(cachekey))
            {
                cacheDictionary.Remove(cachekey);
                return true;
            }

            return false;
        }



    }
}
