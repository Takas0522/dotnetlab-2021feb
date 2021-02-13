using DotNetLab2021Feb.Api.Datas;
using DotNetLab2021Feb.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLab2021Feb.Api.Domains
{
    public class OrderService : IOrderService
    {
        private readonly IOrderData _data;
        public OrderService(
            IOrderData data
        )
        {
            _data = data;
        }

        public async Task<IEnumerable<OrderView>> GetOrders()
        {
            return await _data.GetOrders();
        }
    }
}
