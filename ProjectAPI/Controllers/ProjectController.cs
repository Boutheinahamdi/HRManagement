using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Models;
using ProjectAPI.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IGenericRepo _repository;

        public ProjectController( IGenericRepo repository)
        {
            _repository=repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            var projects = await _repository.GetProjects();
            return Ok(projects);
        }
		



		[HttpGet("{id}", Name = "GetProject")]
        public async Task<ActionResult<Project>> GetProjectById(string id)
        {
            var project = await _repository.GetProjectById(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(Project project)
        {
            await _repository.AddProject(project);

            return CreatedAtRoute("GetProject", new { id = project.Id.ToString() }, project);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            var project = await _repository.GetProjectById(id);

            if (project == null)
            {
                return NotFound();
            }

            var isDeleted = await _repository.DeleteProject(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return StatusCode(500);
        }
    }
}
