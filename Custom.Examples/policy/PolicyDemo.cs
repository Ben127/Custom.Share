using Polly;
using Polly.Timeout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Custom.Examples.policy
{
    /// <summary>
    /// PolicyDemo
    /// </summary>
    public class PolicyDemo
    {
        /// <summary>
        ///  超时
        /// </summary>
        public static void Timeout()
        {
            /*
            * 
            * Polly支持两种超时策略：
                       TimeoutStrategy.Pessimistic： 悲观模式
                       当委托到达指定时间没有返回时，不继续等待委托完成，并抛超时TimeoutRejectedException异常。
            * 
                       TimeoutStrategy.Optimistic：乐观模式
                       这个模式依赖于 co-operative cancellation，只是触发CancellationTokenSource.Cancel函数，需要等待委托自行终止操作。
            * 
            */
            var cts = new CancellationTokenSource();
            try
            {
                Policy.Timeout(3)
                           .Execute(ct =>
                           {

                               for (int i = 0; i < 1000; i++)
                               {
                                   Thread.Sleep(100);
                                   ct.ThrowIfCancellationRequested();
                                   Console.WriteLine("测试" + (i + 1) + "\t" + 100 * (i + 1) + " ms");
                               }


                           }, cts.Token);
            }
            catch (TimeoutRejectedException ex)
            {
                Console.WriteLine("超时> " + ex.Message);
            }
        }

        /// <summary>
        ///  重试
        /// </summary>
        public static void Retry()
        {
            /*
             * 
             *  重试
             * 
             */

            try
            {
                Policy.Handle<Exception>()
                                .Retry(3, (ex, count) =>
                                {
                                    Console.WriteLine("正在重试....." + count);
                                })
                                .Execute(() =>
                                {
                                    string s = null;
                                    var result = s.ToString();

                                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("重试 " + ex.Message);
            }
        }

        /// <summary>
        ///  策略  组合
        /// </summary>
        public static void PolicyWrap()
        {
            // 组合

            var time = Policy.Timeout(3, TimeoutStrategy.Pessimistic);
            var retry = Policy.Handle<Exception>()
                                        .Retry(2);
            var wrap = retry.Wrap(time);        // == Policy.Wrap(retry,time)
            wrap.Execute(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("测试" + (i + 1) + "\t" + 100 * (i + 1) + " ms");
                }

            });

        }

    }
}
