using DotNetLab2021Feb.Api.Context;
using DotNetLab2021Feb.Api.Domains;
using DotNetLab2021Feb.Api.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLab2021Feb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SamplesController : ControllerBase
    {

        private readonly DotNetLab2021FebDatabaseContext _context;

        public SamplesController(DotNetLab2021FebDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Sample> Get()
        {
            return _context.Samples;
        }
    }
}
