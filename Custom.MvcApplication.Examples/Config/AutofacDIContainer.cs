using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.MvcApplication.Examples
{
    public class AutofacDIContainer
    {
        private static IContainer Container;

        /// <summary>
        /// 设置容器
        /// </summary>
        /// <param name="container"></param>
        public static void SetContainer(IContainer container)
        {
            Container = container;
        }

        /// <summary>
        /// 获取容器
        /// </summary>
        /// <returns></returns>
        public static IContainer GetContainer()
        {
            return Container;
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static TService Resolve<TService>()
        {
            if (Container == null)
            {
                throw new ArgumentException("IContainer 没有初始化");
            }

            return Container.Resolve<TService>();

        }

        /// <summary>
        /// 获取服务
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Resolve(Type type)
        {
            if (Container == null)
            {
                throw new ArgumentException("IContainer 没有初始化");
            }
            return Container.Resolve(type);
        }


        /// <summary>
        /// 检查服务是否注册成功
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static bool IsRegistered<TService>()
        {
            return Container.IsRegistered<TService>();
        }

        /// <summary>
        /// 检查服务是否注册成功
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static bool IsRegistered(Type type)
        {
            return Container.IsRegistered(type);
        }

    }

}
