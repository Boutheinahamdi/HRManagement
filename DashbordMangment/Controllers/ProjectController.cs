﻿using DashbordMangment.Models;
using DashbordMangment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
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

		public async Task<IActionResult> KananBoard()
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
		public async Task<IActionResult> Add(string pname, int progress, string deadline, string description)
		{

			Project project = new Project();
			project.Name= pname;
			project.progress= progress;
			project.Deadline= deadline;
			project.Description = description;


			var json = JsonConvert.SerializeObject(project);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _httpclientProject.PostAsync("/api/Project", content);





			return RedirectToAction("Index");
		}

	}
}
