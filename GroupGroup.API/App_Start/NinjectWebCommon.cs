using GrubGroup.Domain.Common;
using GrubGroup.Domain.Repositories.Identity;
using GrubGroup.Domain.Repositories.Logging;
using GrubGroup.Domain.Services.Logging;
using GrubGroup.Infrastructure.Common;
using GrubGroup.Infrastructure.Repositories.Identity;
using GrubGroup.Infrastructure.Repositories.Logging;
using GrubGroup.Infrastructure.Services.Logging;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(GroupGroup.API.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(GroupGroup.API.App_Start.NinjectWebCommon), "Stop")]

namespace GroupGroup.API.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

	public static class NinjectWebCommon
	{
		private static readonly Bootstrapper bootstrapper = new Bootstrapper();

		/// <summary>
		/// Starts the application
		/// </summary>
		public static void Start()
		{
			DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
			DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
			bootstrapper.Initialize(CreateKernel);
		}

		/// <summary>
		/// Stops the application.
		/// </summary>
		public static void Stop()
		{
			bootstrapper.ShutDown();
		}

		/// <summary>
		/// Creates the kernel that will manage your application.
		/// </summary>
		/// <returns>The created kernel.</returns>
		private static IKernel CreateKernel()
		{
			var kernel = new StandardKernel();
			try
			{
				kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
				kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

				RegisterServices(kernel);
				return kernel;
			}
			catch
			{
				kernel.Dispose();
				throw;
			}
		}

		/// <summary>
		/// Load your modules or register your services here!
		/// </summary>
		/// <param name="kernel">The kernel.</param>
		private static void RegisterServices(IKernel kernel)
		{
			kernel.Bind<IDbConnectionFactory>().To<DbConnectionFactory>().InRequestScope();

			#region Repositories

			kernel.Bind<IErrorLogRepository>().To<ErrorLogRepository>().InRequestScope();
			kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();

			#endregion Repositories

			#region Services

			kernel.Bind<IErrorLogService>().To<ErrorLogService>().InRequestScope();

			#endregion Services
		}
	}
}
