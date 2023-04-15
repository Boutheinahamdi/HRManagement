using DashbordMangment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
		public async Task<IActionResult> manage()
		{
			var response = await _httpclientJob.GetAsync("/api/Job");
			var content = await response.Content.ReadAsStringAsync();
			var JobList = JsonConvert.DeserializeObject<IEnumerable<Job>>(content);




			return View(JobList);
		}
		[HttpPost]
		public async Task<IActionResult> Add(string title, string location, int vacancy, int experience, string salary, [FromForm] string jobType, string PostDate, string LastDate, string description)
		{
			Job job=new Job();	
			job.title = title;
			job.description = description;	
			job.lastdate= LastDate;
			job.PostDate = PostDate; 
			job.vacancy=vacancy;	
			job.salary=salary;
			job.experience= experience;
			job.JobType = jobType;
			job.location= location; 
			
			

			var json = JsonConvert.SerializeObject(job);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _httpclientJob.PostAsync("/api/Job", content);





			return RedirectToAction("manage");
		}
	}
}
