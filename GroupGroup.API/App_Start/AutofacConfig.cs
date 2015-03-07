﻿using System.Reflection;
using Autofac;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using GrubGroup.Infrastructure.Identity.Managers;

namespace GroupGroup.API
{
    public class AutofacConfig
    {
        public static IContainer Configure(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // needed to generate user tokens to confirm account registration and for password reset tokens
            // see http://tech.trailmax.info/2014/09/aspnet-identity-and-ioc-container-registration/
            builder.Register(p => app.GetDataProtectionProvider()).As<IDataProtectionProvider>();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            // Configure user manager to be available on the OWIN context because ASP.Net Identity needs it internally
            app.CreatePerOwinContext(() => container.Resolve<GrubGroupUserManager>());

            return container;
        }
    }
}