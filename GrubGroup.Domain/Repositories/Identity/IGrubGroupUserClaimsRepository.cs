using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using GrubGroup.Domain.Models.Identity;

namespace GrubGroup.Domain.Repositories.Identity
{
    public interface IGrubGroupUserClaimsRepository<T> where T : Claim
	{
		Task<IList<ClaimsIdentity>> FindByUserId(Guid userId);
		Task<Guid> Insert(T userClaim, Guid userId);
		Task<bool> DeleteUserClaims(Guid userId);
		Task<bool> Delete(GrubGroupUser user, T userClaim);
	    Task<bool> Delete(Guid userClaimId);
	}
}
