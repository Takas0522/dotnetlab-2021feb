using DotNetLab2021Feb.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetLab2021Feb.Api.Domains
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderView>> GetOrders();
    }
}