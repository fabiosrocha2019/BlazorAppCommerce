using System.Data.Common;
using System.Data;
using Dapper;

namespace BlazorAppCommerce.Interfaces
{
    public interface IDapperService
    {
        DbConnection GetConnection();
        IEnumerable<T> GetAllAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
        T GetByIdAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
        T GetByNameAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
        Task<bool> InsertAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
        T UpdateAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
        int Execute<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure);
    }
}
