using DashbordMangment.Models;
using DashbordMangment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;


namespace DashbordMangment.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly HttpClient _httpclientProject;

        public ProjectController(IHttpClientFactory httpClientFactory, ILogger<ProjectController> logger)
        {

            _logger = logger;
            _httpclientProject = httpClientFactory.CreateClient("ProjectAPI");
        }
        public async Task<IActionResult> Index()
        {   
            var response = await _httpclientProject.GetAsync("/api/Project");
            var content = await response.Content.ReadAsStringAsync();
            var ProjectList = JsonConvert.DeserializeObject<IEnumerable<Project>>(content);
            



            return View(ProjectList);

        }
		// GET: Products/Delete/5
		public async Task<IActionResult> Delete(string? id)
		{
			
			var response = await _httpclientProject.DeleteAsync($"/api/Project/{id}");
			return RedirectToAction("Index");

		}
		
	}
}
