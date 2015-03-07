﻿using Microsoft.AspNet.Identity;
﻿using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using GrubGroup.Domain.Models.Identity;

namespace GrubGroup.Infrastructure.Identity.Managers
{
	public class GrubGroupSignInManager : SignInManager<GrubGroupUser, string>
	{
		public GrubGroupSignInManager(UserManager<GrubGroupUser, string> userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
		{
		}
	}
}
