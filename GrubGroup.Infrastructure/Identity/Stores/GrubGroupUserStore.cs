﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GrubGroup.Domain.Models.Identity;
using Microsoft.AspNet.Identity;

namespace GrubGroup.Infrastructure.Identity.Stores
{
	public class GrubGroupUserStore<T, TKey> :
		IUserLoginStore<T, TKey>,
		IUserClaimStore<T, TKey>,
		IUserRoleStore<T, TKey>,
		IUserPasswordStore<T, TKey>,
		IUserSecurityStampStore<T, TKey>,
		IQueryableUserStore<T, TKey>,
		IUserEmailStore<T, TKey>,
		IUserPhoneNumberStore<T, TKey>,
		IUserTwoFactorStore<T, TKey>,
		IUserLockoutStore<T, TKey>
		where T : GrubGroupUser, IUser<TKey>
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public Task CreateAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task<T> FindByIdAsync(TKey userId)
		{
			throw new NotImplementedException();
		}

		public Task<T> FindByIdAsync(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<T> FindByNameAsync(string userName)
		{
			throw new NotImplementedException();
		}

		public Task AddLoginAsync(T user, UserLoginInfo login)
		{
			throw new NotImplementedException();
		}

		public Task RemoveLoginAsync(T user, UserLoginInfo login)
		{
			throw new NotImplementedException();
		}

		public Task<IList<UserLoginInfo>> GetLoginsAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task<T> FindAsync(UserLoginInfo login)
		{
			throw new NotImplementedException();
		}

		public Task<IList<Claim>> GetClaimsAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task AddClaimAsync(T user, Claim claim)
		{
			throw new NotImplementedException();
		}

		public Task RemoveClaimAsync(T user, Claim claim)
		{
			throw new NotImplementedException();
		}

		public Task AddToRoleAsync(T user, string roleName)
		{
			throw new NotImplementedException();
		}

		public Task RemoveFromRoleAsync(T user, string roleName)
		{
			throw new NotImplementedException();
		}

		public Task<IList<string>> GetRolesAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task<bool> IsInRoleAsync(T user, string roleName)
		{
			throw new NotImplementedException();
		}

		public Task SetPasswordHashAsync(T user, string passwordHash)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetPasswordHashAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task<bool> HasPasswordAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task SetSecurityStampAsync(T user, string stamp)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetSecurityStampAsync(T user)
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> Users { get; private set; }
		public Task SetEmailAsync(T user, string email)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetEmailAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task<bool> GetEmailConfirmedAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task SetEmailConfirmedAsync(T user, bool confirmed)
		{
			throw new NotImplementedException();
		}

		public Task<T> FindByEmailAsync(string email)
		{
			throw new NotImplementedException();
		}

		public Task SetPhoneNumberAsync(T user, string phoneNumber)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetPhoneNumberAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task<bool> GetPhoneNumberConfirmedAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task SetPhoneNumberConfirmedAsync(T user, bool confirmed)
		{
			throw new NotImplementedException();
		}

		public Task SetTwoFactorEnabledAsync(T user, bool enabled)
		{
			throw new NotImplementedException();
		}

		public Task<bool> GetTwoFactorEnabledAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task<DateTimeOffset> GetLockoutEndDateAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task SetLockoutEndDateAsync(T user, DateTimeOffset lockoutEnd)
		{
			throw new NotImplementedException();
		}

		public Task<int> IncrementAccessFailedCountAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task ResetAccessFailedCountAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetAccessFailedCountAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task<bool> GetLockoutEnabledAsync(T user)
		{
			throw new NotImplementedException();
		}

		public Task SetLockoutEnabledAsync(T user, bool enabled)
		{
			throw new NotImplementedException();
		}
	}
}
