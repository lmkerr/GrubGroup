using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GrubGroup.Domain.Common;
using GrubGroup.Domain.Models.Identity;
using GrubGroup.Domain.Repositories.Identity;

namespace GrubGroup.Infrastructure.Identity.Repositories
{
	public class GrubGroupUserRolesRepository<T> : IGrubGroupUserRolesRepository<T> where T : GrubGroupUser
	{
		private readonly IDbConnectionFactory _dbConnectionFactory;

		public GrubGroupUserRolesRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}

		public async  Task<IList<GrubGroupRole>> FindByUserId(Guid userId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"SELECT UR.UserId, R.RoleId, R.Name 
											FROM [Identity].[UserRole] UR
												INNER JOIN [Identity].[Role] R on R.RoleId = UR.RoleId
											WHERE UR.UserId = @UserId";

				var result = await connection.QueryAsync<GrubGroupRole>(query, new
				{
					UserId = userId,
				});

				return result.ToList();
			}
		}

		public async Task<bool> Delete(Guid roleId, Guid userId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				try
				{
					const string query = @"DELETE FROM [Identity].[UserRole]
											WHERE UserId = @UserId AND RoleId = @RoleId";

					var result = await connection.ExecuteAsync(query, new
					{
						UserId = userId,
						RoleId = roleId
					});

					return true;
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}

		public async Task<bool> DeleteByRoleId(Guid roleId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				try
				{
					const string query = @"DELETE FROM [Identity].[UserRole]
											WHERE RoleId = @RoleId";

					var result = await connection.ExecuteAsync(query, new
					{
						RoleId = roleId,
					});

					return true;
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}

		public async Task<bool> DeleteByUserId(Guid userId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				try
				{
					const string query = @"DELETE FROM [Identity].[UserRole]
											WHERE UserId = @UserId";

					var result = await connection.ExecuteAsync(query, new
					{
						UserId = userId
					});

					return true;
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}

		public async Task<Guid> Insert(T user, Guid roleId)
		{
			throw new NotImplementedException();
		}

		public async Task<Guid> Insert(GrubGroupRole role)
		{
			throw new NotImplementedException();
		}

		public async Task<string> GetRoleName(Guid roleId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"SELECT Name 
										FROM [Identity].[Role] 
										WHERE RoleId = @RoleId";

				var result = await connection.QueryAsync<string>(query, new
				{
					RoleId = roleId
				});

				return result.FirstOrDefault();
			}
		}

		public async Task<Guid> GetRoleId(string roleName)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"SELECT RoleId 
										FROM [Identity].[Role] 
										WHERE RoleName = @RoleName";

				var result = await connection.QueryAsync<Guid>(query, new
				{
					RoleName = roleName
				});

				return result.FirstOrDefault();
			}
		}
	}
}
