﻿using System;
﻿using Microsoft.AspNet.Identity;
﻿using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using GrubGroup.Domain.Models.Identity;

namespace GrubGroup.Infrastructure.Identity.Managers
{
	public class GrubGroupSignInManager : SignInManager<GrubGroupUser, Guid>
	{
		public GrubGroupSignInManager(UserManager<GrubGroupUser, Guid> userManager, IAuthenticationManager authenticationManager)
			: base(userManager, authenticationManager)
		{
		}
	}
}
