using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using GrubGroup.Domain.Common;
using GrubGroup.Domain.Models.Identity;
using GrubGroup.Domain.Repositories.Identity;

namespace GrubGroup.Infrastructure.Identity.Repositories
{
    public class GrubGroupUserRepository<T> : IGrubGroupUserRepository<T> where T : GrubGroupUser
	{
		private readonly IDbConnectionFactory _dbConnectionFactory;

        public GrubGroupUserRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}

		public string GetUserName(Guid userId)
		{
			using(var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = "SELECT UserName " +
				                     "FROM Identity.User" +
				                     "WHERE UserId = @UserId";

				return connection.Query<string>(query, new
				{
					UserId = userId
				}).FirstOrDefault();
			}
		}

		public Guid GetUserId(string userName)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
                const string query = "SELECT UserId " +
									 "FROM Identity.User" +
									 "WHERE UserName = @UserName";

				return connection.Query<Guid>(query, new
				{
					UserName = userName
				}).FirstOrDefault();
			}
		}

		public T GetUserById(Guid userId)
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
