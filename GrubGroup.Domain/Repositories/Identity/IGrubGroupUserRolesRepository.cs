using System.Collections.Generic;
using GrubGroup.Domain.Models.Identity;

namespace GrubGroup.Domain.Repositories.Identity
{
    public interface IGrubGroupUserRolesRepository<T> where T : GrubGroupUser
	{
		IList<string> FindByUserId(int userId);
		void Delete(int userId);
		void Insert(T user, int roleId);
	}
}
