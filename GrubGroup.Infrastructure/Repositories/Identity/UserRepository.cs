using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GrubGroup.Domain.Models.Identity;
using GrubGroup.Domain.Repositories.Identity;
using GrubGroup.Infrastructure.Common;

namespace GrubGroup.Infrastructure.Repositories.Identity
{
	public class UserRepository : IUserRepository
	{
		private readonly DbConnectionFactory _factory;

		public UserRepository(DbConnectionFactory factory)
		{
			_factory = factory;
		}

		public User FindById(Guid userId)
		{
			try
			{
				const string query = @"SELECT
											[UserId],
											[Email],
											[CreatedById],
											[CreatedByOn],
											[CreatedByIp],
											[ModifiedById],
											[ModifiedOn],
											[ModifiedByIp]
									FROM User
									WHERE UserId = @UserId";

				using (var connection = _factory.GetConnection())
				{
					return connection.Query<User>(query, new
					{
						UserId = userId
					}).FirstOrDefault();
				}
			}
			catch (Exception ex)
			{
				return new User();
			}
		}

		public IQueryable<User> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
