using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrubGroup.Domain.Models.Identity;
using Microsoft.AspNet.Identity;

namespace GrubGroup.Domain.Repositories.Identity
{
    public interface IGrubGroupUserLoginsRepository<T> where T : GrubGroupUser
	{
		Task<bool> Delete(T user, UserLoginInfo loginInfo);
		Task<bool> Delete(Guid userId);
		Task<Guid> Insert(T user, UserLoginInfo loginInfo);
		Task<Guid> FindUserIdByLogin(UserLoginInfo loginInfo);
		Task<IList<UserLoginInfo>> FindByUserId(Guid userId);
	}
}
