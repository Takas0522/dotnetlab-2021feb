using Dapper;
using DotNetLab2021Feb.Api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLab2021Feb.Api.Datas
{
    public class UserData : IUserData
    {
        private readonly string _connectionString;
        public UserData(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<User>("GetUsers", commandType: System.Data.CommandType.StoredProcedure);
            }
        }


    }
}
