using DotNetLab2021Feb.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetLab2021Feb.Api.Datas
{
    public interface IOrderData
    {
        Task<IEnumerable<OrderView>> GetOrders();
    }
}