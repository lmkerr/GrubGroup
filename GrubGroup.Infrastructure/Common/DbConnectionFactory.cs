using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using GrubGroup.Domain.Common;

namespace GrubGroup.Infrastructure.Common
{
	public class DbConnectionFactory : IDbConnectionFactory
	{
		private readonly List<SqlConnection> _connectionList;
		private readonly string _connectionstring;
		public DbConnectionFactory(string connectionstring)
		{
			_connectionstring = connectionstring;
			_connectionList = new List<SqlConnection>();
		}
		public IDbConnection GetConnection()
		{
			var connection = new SqlConnection(_connectionstring);
			connection.Open();
			_connectionList.Add(connection);
			return connection;
		}

		public void Dispose()
		{
			foreach (var con in _connectionList.Where(con => !con.Equals(null)))
			{
				con.Dispose();
			}
		}
	}
}
