using System;
using System.Data;

namespace GrubGroup.Domain.Common
{
	public interface IDbConnectionFactory : IDisposable
	{
		IDbConnection GetConnection();
	}
}
