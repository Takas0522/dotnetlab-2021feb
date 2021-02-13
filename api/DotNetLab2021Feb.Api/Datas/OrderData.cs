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
    public class OrderData : IOrderData
    {
        private readonly string _connectionString;
        public OrderData(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<OrderView>> GetOrders()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<OrderView>("GetOrderView", commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
