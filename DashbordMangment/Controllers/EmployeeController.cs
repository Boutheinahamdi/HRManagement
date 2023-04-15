using DashbordMangment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public async Task<IActionResult> Add( string Fname, string Lname,string Username,string email, string nationality, string joinDate,int phone,string job,string description)
        {

			Employee emp = new Employee();
			emp.Fname= Fname;
			emp.LName= Lname;
			emp.Username= Username;
			emp.phone= phone;
			emp.job= job;
			emp.DateJoin= joinDate;
			emp.email= email;
			emp.nationality= nationality;
			emp.Description = description;


            var json = JsonConvert.SerializeObject(emp);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpclientEmployee.PostAsync("/api/Employe", content);





            return RedirectToAction("Index");
        }
		public async Task<IActionResult> Profile(string? id)
		{

			var response = await _httpclientEmployee.GetAsync($"/api/Employe/{id}");
			var content = await response.Content.ReadAsStringAsync();
			Employee Employe = JsonConvert.DeserializeObject<Employee>(content);
			IEnumerable<Employee> myEnumerable = new List<Employee>();
			myEnumerable = myEnumerable.Append(Employe);

			return View(myEnumerable);

		}

	}
}
