using System.Collections.Generic;
using GrubGroup.Domain.Models.Identity;

namespace GrubGroup.Domain.Repositories.Identity
{
	public interface IUserRepository<T> where T : GrubGroupUser
	{
		string GetUserName(string userId);
		int GetUserId(string userName);
		T GetUserById(string userId);
		void Insert(T user);
		void Delete(T user);
		void Update(T user);
		IList<T> GetUserByName(string userName);
	}
}
