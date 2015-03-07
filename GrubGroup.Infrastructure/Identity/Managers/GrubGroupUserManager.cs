
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using GrubGroup.Infrastructure.Services.Identity;
﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using GrubGroup.Domain.Models.Identity;

namespace GrubGroup.Infrastructure.Identity.Managers
{
	public class GrubGroupUserManager : UserManager<GrubGroupUser, string>
	{
		public GrubGroupUserManager(IUserStore<GrubGroupUser, string> store, IDataProtectionProvider dataProtectionProvider) : base(store)
		{
			// Configure validation logic for usernames
			this.UserValidator = new UserValidator<GrubGroupUser, string>(this)
			{
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = true
			};

			// Configure validation logic for passwords
			this.PasswordValidator = new PasswordValidator
			{
				RequiredLength = 6,
				RequireNonLetterOrDigit = true,
				RequireDigit = true,
				RequireLowercase = true,
				RequireUppercase = true
			};


			// Configure user lockout defaults
			this.UserLockoutEnabledByDefault = true;
			this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
			this.MaxFailedAccessAttemptsBeforeLockout = 5;



			// Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
			// You can write your own provider and plug it in here.
			this.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<GrubGroupUser, string>
			{
				MessageFormat = "Your security code is {0}"
			});
			this.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<GrubGroupUser, string>
			{
				Subject = "Security Code",
				BodyFormat = "Your security code is {0}"
			});

			this.EmailService = new EmailService();
			this.SmsService = new SmsService();

			this.ClaimsIdentityFactory = new ClaimsIdentityFactory<GrubGroupUser, string>();

			if (dataProtectionProvider != null)
			{
				this.UserTokenProvider =
					new DataProtectorTokenProvider<GrubGroupUser, string>(dataProtectionProvider.Create("ASP.NET Identity"));
			}
		}

	}
}
