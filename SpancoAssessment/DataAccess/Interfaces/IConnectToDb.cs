using Dapper;
using System.Data.Common;

namespace DataAccess.Interfaces
{
    public interface IConnectToDb
    {
        DbConnection SetUpConnection();
        bool ExecuteSP(string spName, DynamicParameters parameters);
    }
}
