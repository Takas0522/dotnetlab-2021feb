using DotNetLab2021Feb.Api.Context;
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
    public class DepartmentsController : ControllerBase
    {
        private readonly DotNetLab2021FebDatabaseContext _context;
        public DepartmentsController(
            DotNetLab2021FebDatabaseContext context
        )
        {
            _context = context;
        }

        [HttpGet]
        [EnableQuery()]
        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments;
        }
    }
}
