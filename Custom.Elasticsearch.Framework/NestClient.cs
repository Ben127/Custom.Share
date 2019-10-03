using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;

namespace Custom.Elasticsearch.Framework
{
    /// <summary>
    ///  NestClient
    /// </summary>
    public class NestClient
    {
        public static bool DebuggerMode { get; set; }

        static ElasticClient client;
        static NestClient()
        {
            Init();
        }

        private static void Init()
        {
            if (client == null)
            {
                var nodes = GetNodes();
                var pool = new StaticConnectionPool(nodes);
                var settings = new ConnectionSettings(pool);

                bool debugger = false;
                string debuggerStr = EsConfig.DebuggerMode;
                debugger = bool.TryParse(debuggerStr, out debugger) ? debugger : false;
                if (debugger)
                {
                    /*
                     *   Debugger 模式
                     *   自动生成 query查询语句和返回内容 response [正式版关闭，避免性能差异]
                     */
                    settings.DisableDirectStreaming(debugger);
                    DebuggerMode = debugger;
                }

                client = new ElasticClient(settings);

            }

        }


        private static Uri[] GetNodes()
        {
            Uri[] nodes = null;
            string nodeStr = EsConfig.Nodes;
            if (!string.IsNullOrEmpty(nodeStr))
            {
                string[] nodeArr = nodeStr.Split(EsConfig.SplitChar)
                    .Where(p => !string.IsNullOrEmpty(p)).ToArray();
                nodes = nodeArr.Select(p => new Uri(p)).ToArray();
            }
            return nodes;

        }



        /// <summary>
        ///  查询ES数据列表
        /// </summary>
        /// <typeparam name="T">数据模型</typeparam>
        /// <param name="index">索引名称 [db]</param>
        /// <param name="from">查询开始记录数</param>
        /// <param name="size">查询条数</param>
        /// <param name="selector">查询条件</param>
        /// <returns></returns>
        public static List<T> Search<T>(Enum_Index index, int from, int size, Func<SearchDescriptor<T>, ISearchRequest> selector) where T : class
        {
            return Search<T>(index.ToString(), from, size, selector);
        }


        /// <summary>
        ///  查询ES数据列表
        /// </summary>
        /// <typeparam name="T">数据模型</typeparam>
        /// <param name="index">索引名称 [db]</param>
        /// <param name="from">查询开始记录数</param>
        /// <param name="size">查询条数</param>
        /// <param name="selector">查询条件</param>
        /// <returns></returns>
        public static List<T> Search<T>(string index, int from, int size, Func<SearchDescriptor<T>, ISearchRequest> selector) where T : class
        {
            Func<SearchDescriptor<T>, ISearchRequest> where = p => p.Index(index).From(from).Size(size);

            if (selector != null)
            {
                where = where + selector;
            }

            var response = client.Search<T>(where);
            if (response.OriginalException != null)
                throw new ArgumentException(response.OriginalException.Message, response.OriginalException);

            if (DebuggerMode && response.ApiCall != null)
            {
                var url = response.ApiCall.Uri.AbsoluteUri;
                var query = System.Text.Encoding.UTF8.GetString(response.ApiCall.RequestBodyInBytes);
                var responseText = System.Text.Encoding.UTF8.GetString(response.ApiCall.ResponseBodyInBytes);

                Debug.WriteLine(string.Format("url：{0}\t\nquery：{1}\t\n response：{2}", url, query, responseText));
            }

            List<T> result = response.Documents.ToList();
            return result;
        }



        /// <summary>
        ///  推送ES数据列表 
        /// </summary>
        /// <typeparam name="T">数据模型</typeparam>
        /// <param name="index">索引枚举</param>
        /// <param name="type">索引类型枚举</param>
        /// <param name="primarykeyName">推送的主键名称</param>
        /// <param name="data">推送数据</param>
        /// <returns></returns>
        public static bool Pulk<T>(Enum_Index index, Enum_Type type, string primarykeyName, List<T> data) where T : class
        {
            return Pulk<T>(index.ToString(), type.ToString(), primarykeyName, data);
        }

        /// <summary>
        ///  推送ES数据列表 
        /// </summary>
        /// <typeparam name="T">数据模型</typeparam>
        /// <param name="index">索引名称 [db]</param>
        /// <param name="type">索引类型 [table]</param>
        /// <param name="primarykeyName">推送的主键名称</param>
        /// <param name="data">推送数据</param>
        /// <returns></returns>
        public static bool Pulk<T>(string index, string type, string primarykeyName, List<T> data) where T : class
        {
            var bulkRequest = new BulkRequest(index, type) { Operations = new List<IBulkOperation>() };

            var indexs = data.Select(p =>
                new BulkIndexOperation<T>(p) { Id = p.GetType().GetProperty(primarykeyName).GetValue(p, null).ToString() })
                .Cast<IBulkOperation>()
                .ToList();

            bulkRequest.Operations = indexs;
            var response = client.Bulk(bulkRequest);

            if (response.OriginalException != null)
            {
                throw new ArgumentException(response.OriginalException.Message, response.OriginalException);
            }
            if (DebuggerMode && response.ApiCall != null)
            {
                var url = response.ApiCall.Uri.AbsoluteUri;
                var query = System.Text.Encoding.UTF8.GetString(response.ApiCall.RequestBodyInBytes);
                var responseText = System.Text.Encoding.UTF8.GetString(response.ApiCall.ResponseBodyInBytes);

                Debug.WriteLine(string.Format("url：{0}\t\nquery：{1}\t\n response：{2}", url, query, responseText));
            }

            return response.IsValid;
        }


        /// <summary>
        ///  删除一条Es数据
        /// </summary>
        /// <param name="index">索引名称 [db]</param>
        /// <param name="type">索引类型 [table]</param>
        /// <param name="primarykeyValue">主键值</param>
        /// <returns></returns>
        public static bool Delete(string index, string type, string primarykeyValue)
        {

            IDeleteRequest request = new DeleteRequest(index, type, primarykeyValue);
            var response = client.Delete(request);
            if (response.OriginalException != null && response.Found)
            {
                throw new ArgumentException(response.OriginalException.Message, response.OriginalException);
            }
            if (DebuggerMode && response.ApiCall != null)
            {
                var url = response.ApiCall.Uri.AbsoluteUri;
                var responseText = System.Text.Encoding.UTF8.GetString(response.ApiCall.ResponseBodyInBytes);

                Debug.WriteLine(string.Format("url：{0}\t\n response：{1}", url, responseText));
            }

            return response.IsValid;

        }


    }


}
