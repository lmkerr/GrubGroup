using System;
using System.Collections.Generic;
using GrubGroup.Domain.Common;
using GrubGroup.Domain.Models.Identity;
using GrubGroup.Domain.Repositories.Identity;

namespace GrubGroup.Infrastructure.Identity.Repositories
{
	public class UserRepository<T> : IUserRepository<T> where T : GrubGroupUser
	{
		private readonly IDbConnectionFactory _dbConnectionFactory;

		public UserRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}

		public string GetUserName(string userId)
		{
			throw new NotImplementedException();
		}

		public int GetUserId(string userName)
		{
			throw new NotImplementedException();
		}

		public T GetUserById(string userId)
		{
			throw new NotImplementedException();
		}

		public void Insert(T user)
		{
			throw new NotImplementedException();
		}

		public void Delete(T user)
		{
			throw new NotImplementedException();
		}

		public void Update(T user)
		{
			throw new NotImplementedException();
		}

		public IList<T> GetUserByName(string userName)
		{
			throw new NotImplementedException();
		}
	}
}
