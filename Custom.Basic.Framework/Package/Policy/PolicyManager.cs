using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Basic.Framework.Package
{
    /// <summary>
    /// PolicyManager
    /// </summary>
    public class PolicyManager
    {
        /// <summary>
        ///  重试策略
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func">执行内容</param>
        /// <param name="act">重试执行内容</param>
        /// <param name="retryCount">重试次数，默认 3次</param>
        /// <returns></returns>
        public static TResult HandleResult<TResult>(TResult tResult, Func<TResult> func, Action<TResult, int, Exception> act, int retryCount = 3)
        {
            var result = Policy.HandleResult<TResult>(tResult)
               .Retry(retryCount, (data, count) =>
               {
                   // retry
                   if (act != null)
                       act(data.Result, count, data.Exception);

               })
               .Execute(() =>
               {
                   var executeResult = func();
                   return executeResult;
               });

            return result;

        }

        /// <summary>
        /// 重试策略
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func">执行内容</param>
        /// <param name="retryCount">重试次数，默认 3次</param>
        /// <returns></returns>
        public static TResult HandleResult<TResult>(TResult tResult, Func<TResult> func, int retryCount = 3)
        {
            return HandleResult<TResult>(tResult, func, null, retryCount);
        }


        /// <summary>
        /// 重试策略
        /// </summary>
        /// <typeparam name="TException">异常类型</typeparam>
        /// <param name="func">执行内容</param>
        /// <param name="act">重试执行内容</param>
        /// <param name="retryCount">重试次数，默认3次</param>
        /// <returns></returns>
        public static TException Handle<TException>(Func<TException> func, Action<TException, int> act, int retryCount = 3)
            where TException : Exception
        {
            var result = Policy.Handle<TException>()
                .Retry(retryCount, (data, count) =>
                {
                    if (act != null)
                        act((TException)data, count);
                })
                .Execute(() =>
                {
                    return func();
                });

            return result;
        }

        /// <summary>
        /// 重试策略
        /// </summary>
        /// <typeparam name="TException">异常类型</typeparam>
        /// <param name="func">执行内容</param>
        /// <param name="retryCount">重试次数，默认3次</param>
        /// <returns></returns>
        public static TException Handle<TException>(Func<TException> func, int retryCount = 3)
           where TException : Exception
        {
            return Handle<TException>(func, null, retryCount);
        }




    }
}
