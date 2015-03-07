using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GrubGroup.Domain.Models.Identity;

namespace GrubGroup.Domain.Repositories.Identity
{
    public interface IGrubGroupUserClaimsRepository<T> where T : GrubGroupUser
	{
		ClaimsIdentity FindByUserId(int userId);
		void Insert(Claim userClaim, int userId);
		void Delete(int userId);
		void Delete(T user, Claim claim);
	}
}
