using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrubGroup.Domain.Models.Identity;

namespace GrubGroup.Domain.Repositories.Identity
{
    public interface IGrubGroupUserRepository<T> where T : GrubGroupUser
	{
		Task<string> GetUserName(Guid userId);
		Task<Guid> GetUserId(string userName);
		Task<T> GetUserById(Guid userId);
		Task<Guid> Insert(T user);
		Task<bool> Delete(Guid userId);
		Task<bool> Update(T user);
		Task<IList<T>> GetUserByName(string userName);
	}
}
