using System;
using System.Linq;
using GrubGroup.Domain.Models.Identity;

namespace GrubGroup.Domain.Repositories.Identity
{
	public interface IUserRepository
	{
		User FindById(Guid userId);
		IQueryable<User> GetAll();
	}
}
