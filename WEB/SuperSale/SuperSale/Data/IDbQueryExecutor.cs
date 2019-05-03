using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace SuperSale.Data
{
    public interface IDbQueryExecutor
    {
        Task<int> ExecuteNonQueryAsync(string sql, DynamicParameters parameters = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null);
        Task<(T, int)> ExecuteScalarAsync<T>(string sql, DynamicParameters parameters = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null);
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, DynamicParameters parameters = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null);
        Task<(IEnumerable<T1>, IEnumerable<T2>)> ExecuteQueryTwoSetsAsync<T1, T2>(string sql, DynamicParameters parameters = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null);
        Task<(IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>)> ExecuteQueryThreeSetsAsync<T1, T2, T3>(string sql, DynamicParameters parameters = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null);
        DynamicParameters GenerateDynamicParameters(object obj);
    }
}
