using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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

		public async Task<string> GetUserName(Guid userId)
		{
			using(var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"SELECT UserName 
				                     FROM [Identity].[User]
				                     WHERE UserId = @UserId";

				var result = await connection.QueryAsync<string>(query, new
				{
					UserId = userId
				});

				return result.SingleOrDefault();
			}
		}

		public async Task<Guid> GetUserId(string userName)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
                const string query = @"SELECT UserId 
									 FROM [Identity].[User]
									 WHERE UserName = @UserName";

				var result = await connection.QueryAsync<Guid>(query, new
				{
					UserName = userName
				});
				
				return result.SingleOrDefault();
			}
		}

		public async Task<T> GetUserById(Guid userId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"SELECT UserId, UserName, Email, EmailConfirmed, PasswordHash,
				                     SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled,
				                     LockoutEndDateUtc, LockoutEnabled, AccessFailedCount,
				                     CreatedById, CreatedByIp, CreatedOn,
				                     ModifiedById, ModifiedByIp, ModifiedOn,
				                     DeletedOn
									 FROM [Identity].[User]
									 WHERE UserId = @UserId";

				var result = await connection.QueryAsync<T>(query, new
				{
					UserId = userId
				});

				return result.SingleOrDefault();
			}
		}

		public async Task<Guid> Insert(T user)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"INSERT INTO [Identity].[User]
				                     (UserId, UserName, Email, EmailConfirmed, PasswordHash,
				                     SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, 
				                     LockoutEndDateUtc, LockoutEnabled, AccessFailedCount,
				                     Deleted, DeletedOn,
				                     CreatedById, CreatedByIp, CreatedOn
				                     ModifiedById, ModifiedOn, ModifiedByIp)
									 OUTPUT inserted.UserId
				                     VALUES
				                     (NEWID(), @UserName, @Email, @EmailConfirmed, @PasswordHash,
				                     @SecurityStamp, @PhoneNumber, @PhoneNumberConfirmed, @TwoFactorEnabled,
				                     @LockoutEndDateUtc, @LockoutEnabled, @AccessFailedCount,
				                     @DeletedOn,
				                     @CreatedById, @CreatedByIp, @CreatedOn
				                     @ModifiedById, @ModifiedOn, @ModifiedByIp)
				                     FROM [Identity].[User]
				                     WHERE UserId = @UserId";

				
				var result = await connection.QueryAsync<Guid>(query, new
				{
					UserName = user.UserName,
					Email = user.Email,
					EmailConfirmed = user.EmailConfirmed,
					PasswordHash = user.PasswordHash,
					SecurityStamp = user.SecurityStamp,
					PhoneNumber = user.PhoneNumber,
					PhoneNumberConfirmed = user.PhoneNumberConfirmed,
					TwoFactorEnabled = user.TwoFactorEnabled,
					LockoutEndDateUtc = user.LockoutEndDateUtc,
					LockoutEnabled = user.LockoutEnabled,
					AccessFailedCount = user.AccessFailedCount,
					DeletedOn = user.DeletedOn,
					CreatedById = user.CreatedById,
					CreatedByIp = user.CreatedByIp,
					CreatedOn = user.CreatedOn > DateTime.MinValue ? user.CreatedOn : DateTime.Now
				});

				return result.SingleOrDefault();
			}
		}

		public async Task<bool> Delete(Guid userId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = "DELETE FROM [Identity].[User] WHERE UserId = @UserId";

				var result = await connection.QueryAsync<bool>(query, new
				{
					UserId = userId
				});

				return result.FirstOrDefault();
			}
		}

		public async Task<bool> Update(T user)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"UPDATE [Identity].[User]
				                     SET
				                     UserName = @UserName, 
				                     Email = @Email, 
				                     EmailConfirmed = @EmailConfirmed, 
				                     PasswordHash = @PasswordHash,
				                     SecurityStamp = @SecurityStamp, 
				                     PhoneNumber = @PhoneNumber, 
				                     PhoneNumberConfirmed = @PhoneNumberConfirmed, 
				                     TwoFactorEnabled = @TwoFactorEnabled, 
				                     LockoutEndDateUtc = @LockoutEndDateUtc, 
				                     LockoutEnabled = @LockoutEnabled, AccessFailedCount = @AccessFailedCount,
				                     Deleted = @Deleted, DeletedOn = @DeletedOn,
				                     ModifiedById = @ModifiedById, ModifiedOn = @ModifiedOn, ModifiedByIp = @ModifiedByIp)
				                     WHERE UserId = @UserId";

				try
				{
					var result = await connection.ExecuteAsync(query, new
					{
						UserName = user.UserName,
						Email = user.Email,
						EmailConfirmed = user.EmailConfirmed,
						PasswordHash = user.PasswordHash,
						SecurityStamp = user.SecurityStamp,
						PhoneNumber = user.PhoneNumber,
						PhoneNumberConfirmed = user.PhoneNumberConfirmed,
						TwoFactorEnabled = user.TwoFactorEnabled,
						LockoutEndDateUtc = user.LockoutEndDateUtc,
						LockoutEnabled = user.LockoutEnabled,
						AccessFailedCount = user.AccessFailedCount,
						DeletedOn = user.DeletedOn,
						CreatedById = user.CreatedById,
						CreatedByIp = user.CreatedByIp,
						CreatedOn = user.CreatedOn > DateTime.MinValue ? user.CreatedOn : DateTime.Now
					});
					return true;
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}

		public async Task<IList<T>> GetUserByName(string userName)
		{
			using(var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"SELECT UserId, UserName, Email, EmailConfirmed, PasswordHash,
									 SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, 
									 LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, 
									 CreatedById, CreatedByIp, CreatedOn,
									 ModifiedById, ModifiedByIp, ModifiedOn,
									 DeletedOn
									 FROM [Identity].[User]
									 WHERE UserName = @UserName";

				var result = await connection.QueryAsync<T>(query, new
				{
					UserName = userName
				});

				return result.ToList();
			}
		}
	}
}
