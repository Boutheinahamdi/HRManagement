using DashbordMangment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DashbordMangment.Controllers
{
	public class ApplicantController : Controller
	{
		private readonly ILogger<ApplicantController> _logger;
		private readonly HttpClient _httpclientApplicant;

		public ApplicantController(IHttpClientFactory httpClientFactory, ILogger<ApplicantController> logger)
        {
			_logger = logger;
			_httpclientApplicant = httpClientFactory.CreateClient("JobAPI");

		}
		public async Task<IActionResult> Index()
		{
			var response = await _httpclientApplicant.GetAsync("/api/Appliquant");
			var content = await response.Content.ReadAsStringAsync();
			var applList = JsonConvert.DeserializeObject<IEnumerable<Applicant>>(content);




			return View(applList);

		}
		public IActionResult Apply()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Apply(string name, string email, string message,int phone)
		{
			Applicant applicant = new Applicant();
			applicant.name=name;
			applicant.email =email;
			applicant.message = message;
			applicant.Phone = phone;




			var json = JsonConvert.SerializeObject(applicant);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _httpclientApplicant.PostAsync("/api/Appliquant", content);





			return RedirectToAction("Index");
		}
	}
}
