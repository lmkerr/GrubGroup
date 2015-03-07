using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrubGroup.Domain.Models.Identity;
using Microsoft.AspNet.Identity;

namespace GrubGroup.Domain.Repositories.Identity
{
	public interface IUserLoginsRepository<T> where T : GrubGroupUser
	{
		void Delete(T user, UserLoginInfo loginInfo);
		void Delete(string userId);
		void Insert(T user, UserLoginInfo loginInfo);
		int FindUserIdByLogin(UserLoginInfo loginInfo);
		IList<UserLoginInfo> FindByUserId(string userId);
	}
}
