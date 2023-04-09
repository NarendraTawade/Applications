using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Data
{
    public class DataAccess :IDataAccess
    {
        private readonly IConfiguration _config;
        public DataAccess( IConfiguration config)
        {
            _config = config;

        }

        public async Task<IEnumerable<T>> GetData<T, P> (string query, P parameters, string connctionId = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connctionId));
            return await connection.QueryAsync<T>(query, parameters);
        }

        public async Task SaveData<P>(string query, P parameters, string connctionId = "DefaultConnection") {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connctionId));
            await connection.ExecuteAsync(query, parameters);
        }

    }
}
