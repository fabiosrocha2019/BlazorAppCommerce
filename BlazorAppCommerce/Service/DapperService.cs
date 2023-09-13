using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using BlazorAppCommerce.Interfaces;

namespace BlazorAppCommerce.Service
{
    public class DapperService : IDapperService
    {
        private readonly IDbConnection _dbConnection;
        private readonly IConfiguration _config;
        private readonly string _conn;

        public DapperService(IConfiguration config)
        {
            _config = config;
            _conn = _config.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<T> GetAllAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_conn);
            return db.Query<T>(procedureName, dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
        }

        public T GetByIdAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_conn);
            return db.Query<T>(procedureName, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public T GetByNameAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_conn);
            return db.Query<T>(procedureName, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public DbConnection GetConnection()
        {
            return new SqlConnection(_conn);
        }

        public async Task<bool> InsertAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_conn);
            bool result = false;
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();

                try
                {
                    result = db.Query<bool>(procedureName, dynamicParameters, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();


                }

            }
            catch (Exception e)
            {
                throw;
            }

            return result;

        }

        public T UpdateAsync<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_conn);
            return db.Query<T>(procedureName, dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public int Execute<T>(string procedureName, DynamicParameters dynamicParameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_conn);
            return db.Execute(procedureName, dynamicParameters, commandType: CommandType.StoredProcedure);
        }
    }
}
