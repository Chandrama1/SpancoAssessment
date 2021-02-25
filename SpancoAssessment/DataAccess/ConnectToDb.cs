using Dapper;
using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace DataAccess
{
    public class ConnectToDb : IConnectToDb
    {
        private readonly string _connectionString;
        private static CommandType _commandType = CommandType.StoredProcedure;

        public ConnectToDb(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public DbConnection SetUpConnection()
        {
            string providerName = null;
            var csb = new DbConnectionStringBuilder { ConnectionString = _connectionString };

            if (csb.ContainsKey("provider"))
            {
                providerName = csb["provider"].ToString();
            }
            else
            {
                var css = ConfigurationManager
                                  .ConnectionStrings
                                  .Cast<ConnectionStringSettings>()
                                  .FirstOrDefault(x => x.ConnectionString == _connectionString);
                if (css != null) providerName = css.ProviderName;
            }

            if (providerName != null)
            {
                var providerExists = DbProviderFactories
                                            .GetFactoryClasses()
                                            .Rows.Cast<DataRow>()
                                            .Any(r => r[2].Equals(providerName));
                if (providerExists)
                {
                    var factory = DbProviderFactories.GetFactory(providerName);
                    var dbConnection = factory.CreateConnection();

                    dbConnection.ConnectionString = _connectionString;
                    return dbConnection;
                }
            }
            return null;
        }

        public void Dispose()
        {

        }

        public bool ExecuteSP(string spName, DynamicParameters parameters)
        {
            int affectedRows = 0;
            try
            {
                using (var dbConn = SetUpConnection())
                {
                    if (dbConn.State == ConnectionState.Closed)
                        dbConn.Open();

                    dbConn.Execute(spName, parameters, commandType: _commandType);
                    affectedRows = parameters.Get<int>("@RowCount");
                }
            }
            catch (Exception ex)
            {
            }
            return affectedRows > 0;
        }
    }
}
