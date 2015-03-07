﻿using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using GrubGroup.Domain.Models.Identity;
using GrubGroup.Infrastructure.Identity.Repositories;
using GrubGroup.Infrastructure.Identity.Stores;
using GrubGroup.Infrastructure.Identity.Managers;

namespace GroupGroup.API.DependencyInjection
{
    public class IdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();


            //
            // Repositories

            //builder.RegisterType<GrubGroupUserRepository>()
            //    .As<IGrubGroupUserRepository<GrubGroupUser>>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<GrubGroupRoleRepository>()
            //    .As<IGrubGroupRoleRepository>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<GrubGroupClaimRepository>()
            //    .As<IGrubGroupClaimRepository>()
            //    .InstancePerLifetimeScope();


            //builder.RegisterType<GrubGroupUserClaimsRepository>()
            //    .As<IGrubGroupUserClaimsRepository>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<GrubGroupUserRolesRepository>()
            //    .As<IGrubGroupUserRolesRepository>()
            //    .InstancePerLifetimeScope();


            //
            // Stores

            //builder.RegisterGeneric(typeof(GrubGroupUserStore<,>))
            //    .As(typeof(IUserStore<,>))
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<GrubGroupRoleStore>()
            //    .As<IRoleStore<GrubGroupRole, Guid>>()
            //    .InstancePerLifetimeScope();


            //
            // Managers

            builder.RegisterType<GrubGroupUserManager>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<GrubGroupSignInManager>().AsSelf().InstancePerLifetimeScope();
        }
    }
}