﻿using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using Module = Autofac.Module;

namespace GroupGroup.API.DependencyInjection
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
        }
    }
}