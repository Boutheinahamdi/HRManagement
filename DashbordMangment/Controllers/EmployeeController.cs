using DashbordMangment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DashbordMangment.Controllers
{
    public class EmployeeController : Controller
    {
		private readonly ILogger<ProjectController> _logger;
		private readonly HttpClient _httpclientEmployee;

		public EmployeeController(IHttpClientFactory httpClientFactory, ILogger<ProjectController> logger)
		{

			_logger = logger;
			_httpclientEmployee = httpClientFactory.CreateClient("EmployeAPI");
		}
		public async Task<IActionResult> Index(string? id)
		{    if (id == null)
			{
				var response = await _httpclientEmployee.GetAsync("/api/Employe");
				var content = await response.Content.ReadAsStringAsync();
				var EmployeList = JsonConvert.DeserializeObject<IEnumerable<Employee>>(content);




				return View(EmployeList);
			}
			else
			{
				var response = await _httpclientEmployee.GetAsync($"/api/Employe/{id}");
				var content = await response.Content.ReadAsStringAsync();
				Employee Employe = JsonConvert.DeserializeObject<Employee>(content);
				IEnumerable<Employee> myEnumerable = new List<Employee>();
				myEnumerable = myEnumerable.Append(Employe);

				return View(myEnumerable);
			}

		}

		public async Task<IActionResult> Delete(string? id)
		{

			var response = await _httpclientEmployee.DeleteAsync($"/api/Employe/{id}");
			return RedirectToAction("Index");

		}
		

	}
}
