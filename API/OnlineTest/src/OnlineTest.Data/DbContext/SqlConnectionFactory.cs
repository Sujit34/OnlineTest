using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnlineTest.Contract.DataContracts;
using OnlineTest.Contract.Utility;

namespace OnlineTest.Data.DbContext
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private IDbConnection _dbConnection;

        private string _connectionString;
        public SqlConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(Common.ConnectionName);
        }

        public IDbConnection GetOpenConnection()
        {
            if (this._dbConnection != null && this._dbConnection.State == ConnectionState.Open)
                return this._dbConnection;
            this._dbConnection = new SqlConnection(_connectionString);
            this._dbConnection.Open();

            return this._dbConnection;
        }

        public void Dispose()
        {
            if (this._dbConnection != null && this._dbConnection.State == ConnectionState.Open)
            {
                this._dbConnection.Dispose();
            }
        }
    }
}
