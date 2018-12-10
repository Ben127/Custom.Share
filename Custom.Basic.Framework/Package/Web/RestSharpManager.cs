using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Package.Web
{
    /// <summary>
    /// httpcontext 操作
    /// </summary>
    public class RestSharpManager
    {

        private static RestClient Client;
        static RestSharpManager()
        {
            Client = new RestClient();
        }

        public static string Get(string url)
        {
            return Get(url, null, null, null, null);
        }

        /// <summary>
        ///  Get 获取url 内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers">header参数</param>
        /// <param name="getData">请求参数</param>
        /// <returns></returns>
        public static string Get(string url, string userName, string password, Dictionary<string, string> headers, Dictionary<string, object> getData)
        {
            Uri uri = new Uri(url);
            Client.BaseUrl = new Uri(string.Format("{0}://{1}", uri.Scheme, uri.Host));

            var request = new RestRequest(uri, Method.GET);
            //header
            if (headers != null && headers.Count > 0)
            {
                foreach (var v in headers)
                {
                    request.AddHeader(v.Key, v.Value);
                }
            }

            // data
            if (getData != null && getData.Count > 0)
            {
                foreach (var v in getData)
                {
                    request.AddParameter(v.Key, v.Value);
                }
            }

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                Client.Authenticator = new HttpBasicAuthenticator(userName, password);
            }

            var respone = Client.Execute(request);

            return respone.Content;

        }


        /// <summary>
        ///  POST 获取post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers">header参数</param>
        /// <param name="postData">post内容</param>
        /// <returns></returns>
        public static string Post(string url, string userName, string password, Dictionary<string, string> headers, Dictionary<string, object> postData)
        {
            Uri uri = new Uri(url);
            Client.BaseUrl = new Uri(string.Format("{0}://{1}", uri.Scheme, uri.Host));

            var request = new RestRequest(uri, Method.POST);

            //header
            if (headers != null && headers.Count > 0)
            {
                foreach (var v in headers)
                {
                    request.AddHeader(v.Key, v.Value);
                }
            }

            // data
            if (postData != null && postData.Count > 0)
            {
                foreach (var v in postData)
                {
                    request.AddParameter(v.Key, v.Value);
                }
            }
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                Client.Authenticator = new HttpBasicAuthenticator(userName, password);
            }

            var respone = Client.Execute(request);

            return respone.Content;

        }


        public static string Post(string url, Dictionary<string, object> postData)
        {
            return Post(url, null, null, null, postData);
        }

    }
}
