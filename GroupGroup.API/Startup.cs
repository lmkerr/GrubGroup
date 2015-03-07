﻿using Autofac;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GroupGroup.API.Startup))]

namespace GroupGroup.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure IoC
            var container = AutofacConfig.Configure(app);

            app.UseAutofacMiddleware(container)
                .RunWebApi(container);


            // Configure ASP.Net Identity settings
            ConfigureAuth(app);
        }
    }
}
