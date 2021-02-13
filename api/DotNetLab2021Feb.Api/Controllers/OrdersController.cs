using DotNetLab2021Feb.Api.Context;
using DotNetLab2021Feb.Api.Domains;
using DotNetLab2021Feb.Api.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLab2021Feb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly DotNetLab2021FebDatabaseContext _context;
        private readonly IOrderService _service;

        public OrdersController(
            DotNetLab2021FebDatabaseContext context,
            IOrderService service
        )
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        [EnableQuery(PageSize = 50000)]
        public IEnumerable<OrderView> GetOrders()
        {
            return _context.OrderViews;
        }

        [HttpGet("full")]
        public async Task<IEnumerable<OrderView>> GetFillOrders()
        {
            return await _service.GetOrders();
        }
    }
}
