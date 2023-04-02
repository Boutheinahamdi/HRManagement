using DashbordMangment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DashbordMangment.Controllers
{
	public class JobController : Controller
	{
		private readonly ILogger<JobController> _logger;
		private readonly HttpClient _httpclientJob;

		public JobController(IHttpClientFactory httpClientFactory, ILogger<JobController> logger)
		{

			_logger = logger;
			_httpclientJob = httpClientFactory.CreateClient("JobAPI");
		}
		public async Task<IActionResult> Index()
		{
			var response = await _httpclientJob.GetAsync("/api/Job");
			var content = await response.Content.ReadAsStringAsync();
			var JobList = JsonConvert.DeserializeObject<IEnumerable<Job>>(content);




			return View(JobList);

		}
		public async Task<IActionResult> Details(string? id)
		{

			var response = await _httpclientJob.GetAsync($"/api/Job/{id}");
			var content = await response.Content.ReadAsStringAsync();
			var Job = JsonConvert.DeserializeObject<Job>(content);

			return View (Job);

		}
	}
}
