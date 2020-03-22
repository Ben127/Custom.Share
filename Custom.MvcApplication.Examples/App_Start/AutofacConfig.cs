using Autofac;
using Autofac.Integration.Mvc;
using Custom.MvcApplication.Examples.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Custom.MvcApplication.Examples
{
    public class AutofacConfig
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();

            //注册控制器
            Assembly controllerAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterControllers(controllerAssembly).ExternallyOwned();

            builder.RegisterType<EntityService>().As<IEntityService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            //builder.RegisterType(typeof(IAccountService)).AsImplementedInterfaces();


            //builder.Register(p => new AccountService(p.Resolve<IEntityService>()));

            var container = builder.Build();

            //注入
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //注入DI容器
            AutofacDIContainer.SetContainer(container);
        }

    }
}