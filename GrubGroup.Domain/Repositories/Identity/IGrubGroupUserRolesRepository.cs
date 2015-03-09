using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GrubGroup.Domain.Models.Identity;
using Microsoft.AspNet.Identity;

namespace GrubGroup.Domain.Repositories.Identity
{
    public interface IGrubGroupUserRolesRepository<T> where T : GrubGroupUser
	{
		Task<IList<GrubGroupRole>> FindByUserId(Guid userId);
	    Task<bool> Delete(Guid roleId, Guid userId);
	    Task<bool> DeleteByRoleId(Guid roleId);
		Task<bool> DeleteByUserId(Guid userId);
		Task<Guid> Insert(T user, Guid roleId);
	    Task<Guid> Insert(GrubGroupRole role);
	    Task<string> GetRoleName(Guid roleId);
	    Task<Guid> GetRoleId(string roleName);
	}
}
