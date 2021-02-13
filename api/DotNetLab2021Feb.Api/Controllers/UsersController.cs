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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(
            IUserService service
        )
        {
            _service = service;
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<IEnumerable<User>> GetUserDatas()
        {
            return await _service.GetUsers();
        }
    }
}
