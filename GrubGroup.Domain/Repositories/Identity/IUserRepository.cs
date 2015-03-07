using System;
using System.Collections.Generic;
using GrubGroup.Domain.Models.Identity;

namespace GrubGroup.Domain.Repositories.Identity
{
	public interface IUserRepository<T> where T : GrubGroupUser
	{
		string GetUserName(Guid userId);
		Guid GetUserId(string userName);
		T GetUserById(Guid userId);
		void Insert(T user);
		void Delete(T user);
		void Update(T user);
		IList<T> GetUserByName(string userName);
	}
}
