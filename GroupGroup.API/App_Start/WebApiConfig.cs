﻿using System.Linq;
using System.Net.Http.Formatting;
using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;

namespace GroupGroup.API
{
    public static class WebApiConfig
    {
        /// <summary>
        /// OWIN Web API IoC Setup
        /// </summary>
        /// <param name="app"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public static IAppBuilder RunWebApi(this IAppBuilder app, IContainer container)
        {
            var config = new HttpConfiguration();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // enable Web API attribute routing
            config.MapHttpAttributeRoutes();

            // also enable convention based routing
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            // use camel case formatter
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;

            // Web API should only use bearer token authentication
            config.SuppressDefaultHostAuthentication();


            return app.UseAutofacWebApi(config)
                .UseWebApi(config);
        }
    }
}
