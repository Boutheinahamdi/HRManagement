using EmployeeApi.Data;
using EmployeeApi.Models;
using EmployeeApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class DepartementController : Controller
	{
		private readonly ILogger<DepartementController> _Logger;
		private readonly IrepositoryEmploye _context;

		public DepartementController(ILogger<DepartementController> logger, IrepositoryEmploye context)
		{
			_Logger = logger;
			_context = context;

		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Departement>>> GetDeps()

		{
			var deps = await _context.GetDepartments();
			return Ok(deps);
		}



		[HttpPost]
		public async Task<ActionResult<Departement>> AddDep(Departement dep)
		{
			dep.ID = ObjectId.GenerateNewId().ToString();
			await _context.AddDepartement(dep);

			return CreatedAtRoute("GetProject", new { id =dep.ID.ToString() }, dep);
		}


		
	}
}
