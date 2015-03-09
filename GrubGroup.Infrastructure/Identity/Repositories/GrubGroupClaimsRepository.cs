using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dapper;
using GrubGroup.Domain.Common;
using GrubGroup.Domain.Models.Identity;
using GrubGroup.Domain.Repositories.Identity;

namespace GrubGroup.Infrastructure.Identity.Repositories
{
	public class GrubGroupClaimsRepository<T> : IGrubGroupUserClaimsRepository<T> where T : Claim
	{
		private readonly IDbConnectionFactory _dbConnectionFactory;

		public GrubGroupClaimsRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}

		public async Task<IList<ClaimsIdentity>> FindByUserId(Guid userId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"SELECT 
											[UserClaimId], [UserId], [ClaimType], [ClaimValue]
										FROM [Identity].[UserClaim] WHERE UserId = @UserId";

				var result = await connection.QueryAsync<ClaimsIdentity>(query, new
				{
					UserId = userId
				});

				return result.ToList();
			}
		}

		public async Task<Guid> Insert(T userClaim, Guid userId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
					const string query = @"INSERT INTO [Identity].[UserClaim]
												(UserClaimId, ClaimValue, ClaimType, UserId)
											VALUES
											OUTPUT inserted.UserClaimId
												(NEWID(), @ClaimValue, @ClaimType, @UserId)";

					var result = await connection.QueryAsync<Guid>(query,
						new
						{
							UserId = userId,
							ClaimValue = userClaim.Value,
							ClaimType = userClaim.Type
						});

					return result.FirstOrDefault();
			}
				
		}

		public async Task<bool> DeleteUserClaims(Guid userId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"DELETE FROM [Identity].[UserClaim] WHERE UserId = @UserId";

				try
				{
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

		public async Task<bool> Delete(GrubGroupUser user, T claim)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"DELETE FROM [Identity].[UserClaim] 
									 WHERE UserId = @UserId AND @ClaimValue 
									= @Value AND ClaimType = @Type";
				try
				{
					var result = await connection.ExecuteAsync(query, new
					{
						UserId = user.Id,
						Value = claim.Value,
						Type = claim.Type
					});
					return true;
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}

		public async Task<bool> Delete(Guid userClaimId)
		{
			using (var connection = _dbConnectionFactory.GetConnection())
			{
				const string query = @"DELETE FROM [Identity].[UserClaim] WHERE UserClaimId = @UserClaimId";

				try
				{
					var result = await connection.ExecuteAsync(query, new
					{
						UserClaimId = userClaimId
					});
					return true;
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}
	}
}
