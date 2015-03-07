using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrubGroup.Domain.Models.Identity;
using Microsoft.AspNet.Identity;

namespace GrubGroup.Infrastructure.Identity.Stores
{
	public class GrubGroupRoleStore<T> : IRoleStore<T> where T : GrubGroupRole
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public Task CreateAsync(T role)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(T role)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(T role)
		{
			throw new NotImplementedException();
		}

		public Task<T> FindByIdAsync(string roleId)
		{
			throw new NotImplementedException();
		}

		public Task<T> FindByNameAsync(string roleName)
		{
			throw new NotImplementedException();
		}
	}
}
