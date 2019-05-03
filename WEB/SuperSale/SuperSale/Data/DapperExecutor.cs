using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static Dapper.SqlMapper;

namespace SuperSale.Data
{
    public class DapperExecutor : IDbQueryExecutor
    {
        private readonly string _connString;
        private const string ReturnCode = "ReturnCode";

        public DapperExecutor(IConfiguration config)
        {            
            _connString = config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(_connString))
                throw new Exception($"Connection string (key: DefaultConnection) is not found in the root configuration ({nameof(IConfiguration)}).");
        }

        public async Task<int> ExecuteNonQueryAsync(string sql, DynamicParameters parameters = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var sw = Stopwatch.StartNew();

                await conn.ExecuteAsync(sql, parameters, commandType: commandType, commandTimeout: commandTimeout);
                              
                return GetReturnCode(parameters);
            }
        }

        public async Task<(T, int)> ExecuteScalarAsync<T>(string sql, DynamicParameters parameters = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var sw = Stopwatch.StartNew();

                var result = await conn.ExecuteScalarAsync<T>(sql, parameters, commandType: commandType, commandTimeout: commandTimeout);

                return (result, GetReturnCode(parameters));
            }
        }

        public async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string sql, DynamicParameters parameters = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var resultSet = await conn.QueryAsync<T>(sql, parameters, commandType: commandType, commandTimeout: commandTimeout);

                return resultSet;
            }
        }

        public async Task<(IEnumerable<T1>, IEnumerable<T2>)> ExecuteQueryTwoSetsAsync<T1, T2>(string sql, DynamicParameters parameters = null, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var sw = Stopwatch.StartNew();

                IEnumerable<T1> resultSet1;
                IEnumerable<T2> resultSet2;

                using (var reader = await conn.QueryMultipleAsync(sql, parameters, commandType: commandType, commandTimeout: commandTimeout))
                {
                    resultSet1 = reader.IsConsumed ? Enumerable.Empty<T1>() : reader.Read<T1>();
                    resultSet2 = reader.IsConsumed ? Enumerable.Empty<T2>() : reader.Read<T2>();

                }

                return (
                          resultSet1,
                          resultSet2
                       );
            }
        }

        public async Task<(IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>)> ExecuteQueryThreeSetsAsync<T1, T2, T3>(string sql, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            using (var conn = new SqlConnection(_connString))
            {
                var sw = Stopwatch.StartNew();

                IEnumerable<T1> resultSet1;
                IEnumerable<T2> resultSet2;
                IEnumerable<T3> resultSet3;

                using (var reader = await conn.QueryMultipleAsync(sql, parameters, commandType: commandType, commandTimeout: commandTimeout))
                {
                    resultSet1 = reader.IsConsumed ? Enumerable.Empty<T1>() : reader.Read<T1>();
                    resultSet2 = reader.IsConsumed ? Enumerable.Empty<T2>() : reader.Read<T2>();
                    resultSet3 = reader.IsConsumed ? Enumerable.Empty<T3>() : reader.Read<T3>();

                }

                return (
                           resultSet1,
                           resultSet2,
                           resultSet3
                        );
            }
        }

       
        private static int GetReturnCode(DynamicParameters parameters)
        {
            return (parameters?.ParameterNames.Contains(ReturnCode) == true)
                ? parameters.Get<int>(ReturnCode)
                : 0;
        }
    }
}
