using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Mvc;
using System.Web;
using Custom.MvcApplication.Examples.Service;

namespace Custom.MvcApplication.Examples
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        public static void Init()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEntityService, EntityService>();
            container.RegisterType<IAccountService, AccountService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}