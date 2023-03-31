using EmployeeApi.Data;
using EmployeeApi.Models;
using EmployeeApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly ILogger<EmployeController> _Logger;
        private readonly EmployeContext _context;

        public EmployeController(ILogger<EmployeController> logger, EmployeContext context)
        {
            _Logger = logger;
            _context = context;

        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> getAllBlogs()

        {
            return await _context.employe.Find(p => true).ToListAsync();
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Employee>> GetByID(string id)
        {
            var emp = await _context.employe.Find(x => x.Fname == id).FirstOrDefaultAsync();

            if (emp is null)
            {
                return NotFound();
            }

            return emp;
        }
        [HttpGet("{job}")]
        public async Task<ActionResult<Employee>> GetByJob(string job)
        {
            var emp = await _context.employe.Find(x => x.job == job).FirstOrDefaultAsync();

            if (emp is null)
            {
                return NotFound();
            }

            return emp;
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee emp)
        {
            emp.ID = ObjectId.GenerateNewId().ToString();
            _context.employe.InsertOne(emp);


              return NoContent(); ;

        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteEmployee(string name)
        {
           

            var emp = await _context.employe.Find(x => x.Fname == name).FirstOrDefaultAsync();

            if (emp is null)
            {
                return NotFound();
            }

        await    _context.employe.DeleteOneAsync(e => e.ID == emp.ID);



            return NoContent(); ;
        }

    }
}
