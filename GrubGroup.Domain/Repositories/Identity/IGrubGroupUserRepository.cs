using System;
using System.Collections.Generic;
using GrubGroup.Domain.Models.Identity;

namespace GrubGroup.Domain.Repositories.Identity
{
    public interface IGrubGroupUserRepository<T> where T : GrubGroupUser
	{
		string GetUserName(Guid userId);
		Guid GetUserId(string userName);
		T GetUserById(Guid userId);
		Guid Insert(T user);
		bool Delete(Guid userId);
		bool Update(T user);
		IList<T> GetUserByName(string userName);
	}
}
