using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GrubGroup.Domain.Common;
using GrubGroup.Domain.Models.Identity;
using GrubGroup.Domain.Repositories.Identity;
using Microsoft.AspNet.Identity;

namespace GrubGroup.Infrastructure.Identity.Repositories
{
	public class GrubGroupUserLoginsRepository<T> : IGrubGroupUserLoginsRepository<T> where T : GrubGroupUser
	{
		private readonly IDbConnectionFactory _dbConnectionFactory;

		public GrubGroupUserLoginsRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
		public async Task<bool> Delete(T user, UserLoginInfo loginInfo)
		{
			try
			{
				using (var connection = _dbConnectionFactory.GetConnection())
				{
					const string query = @"DELETE FROM [Identity].[MemberLogin]
												WHERE UserId = @UserId 
													AND LoginProvider = @LoginProvider 
													AND ProviderKey = @ProviderKey";

					var result = await connection.ExecuteAsync(query, new
					{
						UserId = user.Id,
						LoginProfile = loginInfo.LoginProvider,
						ProviderKey = loginInfo.ProviderKey
					});

					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
			}
			
		}

		public async Task<bool> Delete(Guid userId)
		{
			try
			{
				using (var connection = _dbConnectionFactory.GetConnection())
				{
					const string query = @"DELETE FROM [Identity].[MemberLogin]
											WHERE UserId = @UserId";

					var result = await connection.ExecuteAsync(query, new
					{
						UserId = userId
					});

					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public async Task<Guid> Insert(T user, UserLoginInfo loginInfo)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"INSERT INTO [Identity].[MemberLogin]
											 (UserId, LoginProvider, ProviderKey)
											 OUTPUT inserted.UserId
										 VALUES
											 (NEWID(), @LoginProvider, @ProviderKey)
										 FROM [Identity].[User]
										 WHERE UserId = @UserId";

				var result = await connection.ExecuteScalarAsync<Guid>(query, new
				{
					LoginProvider = loginInfo.LoginProvider,
					ProviderKey = loginInfo.ProviderKey
				});

				return result;
			}
		}

		public async Task<Guid> FindUserIdByLogin(UserLoginInfo loginInfo)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"SELECT UserID FROM [Identity].[MemberLogin]
											WHERE LoginProvider = @LoginProvider
												AND ProviderKey = @ProviderKey";

				var result = await connection.ExecuteScalarAsync<Guid>(query, new
				{
					LoginProvider = loginInfo.LoginProvider,
					ProviderKey = loginInfo.ProviderKey
				});

				return result;
			}
		}

		public async Task<IList<UserLoginInfo>> FindByUserId(Guid userId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"SELECT UserId, LoginProvider, ProviderKey 
											FROM [Identity].[MemberLogin]
											WHERE UserId = @UserId";

				var result = await connection.QueryAsync<UserLoginInfo>(query, new
				{
					UserId = userId,
				});

				return result.ToList();
			}
		}
	}
}
