using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Custom.Basic.Framework.Package.Redis
{
    public class RedisManager
    {
        private ConnectionMultiplexer _connectionMult;
        public RedisManager() :
            this(null)
        {

        }

        /// <summary>
        /// Redis 操作
        /// </summary>
        public RedisManager(string connectionString)
        {
            this._connectionMult = string.IsNullOrEmpty(connectionString) ? RedisConfig.Instance : RedisConfig.GetConnectionMultiplexer(connectionString);
        }



        #region Hash

        /// <summary>
        /// 设置Hash 
        ///        集合Value
        /// <param name="dataKeyFunc">Hash 键值</param>
        /// </summary>
        public bool HashSet<T>(string redisKey, List<T> listData, Func<T, string> dataKeyFunc, TimeSpan? timespan = null)
        {
            return Do(redis =>
                                    {
                                        var batch = redis.CreateBatch();
                                        foreach (var v in listData)
                                        {
                                            string redisValue = ConvertJson<T>(v);
                                            batch.HashSetAsync(redisKey, dataKeyFunc(v), redisValue);
                                        }

                                        batch.Execute();

                                        if (timespan.HasValue)
                                        {
                                            redis.KeyExpire(redisKey, timespan);
                                        }

                                        return true;
                                    });
        }

        /// <summary>
        /// 设置Hash 单个
        ///        单模型  Value
        /// </summary>
        public bool HashSet<T>(string redisKey, string dataKey, T model, TimeSpan? timespan = null)
        {
            return Do(redis =>
                                    {
                                        string json = ConvertJson<T>(model);
                                        bool setSuccess = redis.HashSet(redisKey, dataKey, json);
                                        if (setSuccess && timespan.HasValue)
                                        {
                                            redis.KeyExpire(redisKey, DateTime.Now.Add(timespan.Value));
                                        }

                                        return setSuccess;
                                    });
        }


        /// <summary>
        /// 删除Hash 
        /// </summary>
        public bool HashDelete(string redisKey, List<int> dataKeys)
        {
            return Do(redis =>
                                    {
                                        RedisValue[] redisValues = dataKeys.Select(p => (RedisValue)p.ToString()).ToArray();
                                        return redis.HashDelete(redisKey, redisValues) > 0;
                                    });

        }


        /// <summary>
        /// 是否存在 Hash
        /// </summary>
        public bool HashExists(string redisKey, string dataKey)
        {
            return Do(redis =>
                                    {
                                        return redis.HashExists(redisKey, dataKey);
                                    });
        }


        /// <summary>
        /// 获取Hash 长度
        /// </summary>
        /// <returns></returns>
        public long HashLength(string redisKey)
        {
            return Do(redis =>
                                    {
                                        return redis.HashLength(redisKey);
                                    });
        }

        /// <summary>
        /// Hash 某键值增量
        /// </summary>
        /// <param name="dataKey"></param>
        /// <returns>增长后的值</returns>
        public long HashIncrement(string redisKey, string dataKey, long value = 1)
        {
            return Do(redis =>
                                    {
                                        return redis.HashIncrement(redisKey, dataKey, value);
                                    });
        }


        /// <summary>
        /// Hash 某键值减量
        /// </summary>
        /// <param name="dataKey"></param>
        /// <returns>减量后的值</returns>
        public long HashDecrement(string redisKey, string dataKey, long val = 1)
        {
            return Do(redis =>
                                    {
                                        return redis.HashDecrement(redisKey, dataKey, val);
                                    });
        }


        /// <summary>
        /// 获取Hash所有键
        /// </summary>
        public List<T> HashKeys<T>(string redisKey)
        {
            return Do(redis =>
                                    {
                                        RedisValue[] redisValue = redis.HashKeys(redisKey);
                                        return ConvertCollection<T>(redisValue);
                                    });
        }


        /// <summary>
        /// 获取Hash所有值
        /// </summary>
        public List<T> HashValues<T>(string redisKey)
        {
            return Do(redis =>
                                    {
                                        RedisValue[] redisValues = redis.HashValues(redisKey);
                                        return ConvertCollection<T>(redisValues);
                                    });
        }


        #endregion

        #region List


        /// <summary>
        ///  List列表中删除第一次count出现的元素 
        /// </summary>
        /// <param name="value">将要移除的值</param>
        /// <param name="count">
        ///     count > 0：删除等于value从头到尾移动的元素。
        ///     count < 0：删除等于value从尾部移动到头部的元素。
        ///     count = 0：删除所有等于的元素value。
        /// </param>
        public long ListRemove(string redisKey, string redisValue, long count = 0)
        {
            return Do(redis =>
                                    {
                                        return redis.ListRemove(redisKey, redisValue ?? "", count);
                                    });
        }


        /// <summary>
        ///  获取 List 某键
        /// </summary>
        public T ListGetByIndex<T>(string redisKey)
        {
            return Do(redis =>
                                    {
                                        RedisValue redisValue = redis.ListGetByIndex(redisKey, 0);
                                        return ConvertObj<T>(redisValue);
                                    });
        }


        /// <summary>
        /// 设置Redis 批量list类型值
        ///     入栈，元素逐个添加到头部
        /// </summary>
        public bool ListSetLeftPushCollection<T>(string redisKey, List<T> listData, TimeSpan? timespan)
        {
            return Do(redis =>
                                        {
                                            var batch = redis.CreateBatch();
                                            listData.ForEach((item) =>
                                            {
                                                var task = batch.ListLeftPushAsync(redisKey, ConvertJson<T>(item));
                                                if (timespan.HasValue)
                                                {
                                                    redis.KeyExpire(redisKey, timespan);
                                                }
                                            });
                                            batch.Execute();

                                            return true;

                                        });
        }

        /// <summary>
        /// 设置Redis 批量list类型值
        ///     入队，元素逐个添加到尾部
        /// </summary>
        public bool ListSetRightPushCollection<T>(string redisKey, List<T> listData, TimeSpan? timespan)
        {
            return Do(redis =>
                                    {
                                        var batch = redis.CreateBatch();
                                        listData.ForEach((item) =>
                                        {
                                            var task = batch.ListRightPushAsync(redisKey, ConvertJson<T>(item));
                                            if (timespan.HasValue)
                                            {
                                                redis.KeyExpire(redisKey, timespan);
                                            }
                                        });
                                        batch.Execute();

                                        return true;

                                    });
        }


        #endregion

        #region String

        /// <summary>
        ///  获取Redis 单个string类型值
        /// </summary>
        public T StringGet<T>(string redisKey)
        {
            return Do(redis =>
                                    {
                                        RedisValue redisValue = redis.StringGet(redisKey);
                                        return ConvertObj<T>(redisValue);
                                    });
        }

        /// <summary>
        /// 获取Redis 多个string类型值
        /// </summary>
        public List<T> StringGetCollection<T>(List<string> redisKey)
        {
            return Do(redis =>
                                    {
                                        RedisKey[] redisKeys = redisKey.Select(p => (RedisKey)p.ToString()).ToArray();
                                        RedisValue[] redisValues = redis.StringGet(redisKeys);
                                        return ConvertCollection<T>(redisValues);
                                    });

        }


        /// <summary>
        ///  设置Redis 批量string类型值
        ///         pipe管道
        /// </summary>
        public bool StringSetCollection<T>(List<T> listData, Func<T, string> redisKeyFunc, TimeSpan? timespan)
        {
            return Do(redis =>
            {
                var batch = redis.CreateBatch();
                listData.ForEach((item) =>
                {
                    batch.StringSetAsync(redisKeyFunc(item), ConvertJson<T>(item), timespan);
                });
                batch.Execute();

                return true;
            });
        }


        #endregion

        #region Set     不重复的组合，集合型数据，无顺序

        /// <summary>
        /// 获取Redis Set 列表
        /// </summary>
        public List<T> SetGetCollection<T>(string redisKey)
        {
            return Do(redis =>
                                    {
                                        RedisValue[] redisValue = redis.SetMembers(redisKey).ToArray();
                                        return ConvertCollection<T>(redisValue);
                                    });
        }

        /// <summary>
        /// 设置Redis Set 列表
        /// </summary>
        public bool SetSetCollection<T>(string redisKey, List<T> listData, TimeSpan? timespan)
        {
            return Do(redis =>
            {
                var batch = redis.CreateBatch();
                listData.ForEach((item) =>
                {
                    batch.SetAddAsync(redisKey, ConvertJson<T>(item));
                });
                batch.Execute();
                if (timespan.HasValue)
                {
                    redis.KeyExpire(redisKey, timespan);
                }

                return true;
            });
        }

        #endregion

        #region  SortSet 不重复组合，包含权重，有序

        /// <summary>
        /// 获取Redis SortSet 列表 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="redisKey"></param>
        /// <param name="skip">跳过多少</param>
        /// <param name="take">查询多少项，-1 表示倒数第一项，-2表示倒数第二项，默认null 为全部 </param>
        /// <param name="redisOrder">按权重排序方式</param>
        public List<T> SortSetGet<T>(string redisKey, int skip = 0, int? take = null, Redis_Order redisOrder = Redis_Order.Descending)
        {
            int stop = take.HasValue ? take.Value : -1;
            Order order = redisOrder == Redis_Order.Descending ? Order.Descending : Order.Ascending;
            return Do(redis =>
                                    {
                                        RedisValue[] redisValue = redis.SortedSetRangeByRank(redisKey, skip, stop, order);
                                        return ConvertCollection<T>(redisValue);
                                    });
        }


        /// <summary>
        /// 设置Redis SortSet 列表
        /// </summary>
        /// <param name="scoreExpression">权重分</param>
        public bool SortSetSet<T>(string redisKey, List<T> listData, Func<T, double> scoreExpression, TimeSpan? timespan)
        {
            return Do(redis =>
                                    {
                                        var batch = redis.CreateBatch();
                                        listData.ForEach((item) =>
                                        {
                                            string redisValue = ConvertJson<T>(item);
                                            batch.SortedSetAddAsync(redisKey, redisValue, scoreExpression(item));
                                        });
                                        batch.Execute();
                                        if (timespan.HasValue)
                                        {
                                            redis.KeyExpire(redisKey, timespan);
                                        }

                                        return true;
                                    });
        }


        #endregion


        #region 发布订阅


        /// <summary>
        ///  Redis 订阅
        /// </summary>
        public void Subscribe(string channelName, string redisKey, Action<RedisChannel, RedisValue> act = null)
        {
            ISubscriber sub = this._connectionMult.GetSubscriber();
            sub.Subscribe(channelName, (channel, message) =>
            {
                if (act != null)
                {
                    act(channel, message);
                }
            });
        }

        /// <summary>
        ///  Redis 取消订阅
        /// </summary>
        public void Unsubscribe(string channelName, string redisKey, Action<RedisChannel, RedisValue> act = null)
        {
            ISubscriber sub = this._connectionMult.GetSubscriber();
            sub.Unsubscribe(channelName, (channel, message) =>
            {
                if (act != null)
                {
                    act(channel, message);
                }
            });
        }

        /// <summary>
        ///  Redis 取消所有订阅
        /// </summary>
        public void UnsubscribeAll()
        {
            ISubscriber sub = this._connectionMult.GetSubscriber();
            sub.UnsubscribeAll();
        }


        /// <summary>
        ///  Redis 发布
        /// </summary>
        public void Publish<T>(string channelName, T data)
        {
            ISubscriber sub = this._connectionMult.GetSubscriber();
            string json = ConvertJson<T>(data);
            sub.Publish(channelName, json);
        }

        #endregion


        private T Do<T>(Func<IDatabase, T> func)
        {
            var database = _connectionMult.GetDatabase(0);
            return func(database);
        }


        private static string GetValue<T>(T model, string propertyName)
        {
            var pi = typeof(T).GetProperty(propertyName);
            object obj = pi.GetValue(model, null);
            return obj == null ? "" : obj.ToString();

        }

        private static string ConvertJson<T>(T value)
        {
            string result = value is string ? value.ToString() : JsonConvert.SerializeObject(value);
            return result;
        }

        private static T ConvertObj<T>(RedisValue value)
        {
            if (value.IsNull)
            {
                return default(T);
            }

            if (typeof(T).Name.Equals(typeof(string).Name))
            {
                return JsonConvert.DeserializeObject<T>("'{value}'");
            }
            return JsonConvert.DeserializeObject<T>(value);
        }

        private static List<T> ConvertCollection<T>(RedisValue[] redisValues)
        {
            List<T> result = new List<T>();
            foreach (var v in redisValues)
            {
                T model = ConvertObj<T>(v);
                result.Add(model);
            }

            return result;
        }


    }
}
