using JobAPI.Models;
using JobAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobController : ControllerBase
	{
		private readonly Igeneric _repository;

		public JobController( Igeneric repository)
        {
            _repository=repository;
            
        }


		[HttpGet]
		public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
		{
			var jobs = await _repository.GetJobs();
			return Ok(jobs);
		}

		[HttpGet("{id}", Name = "GetJob")]
		public async Task<ActionResult<Job>> GetJobById(string id)
		{
			var job = await _repository.GetJobById(id);

			if (job == null)
			{
				return NotFound();
			}

			return Ok(job);
		}

		[HttpPost]
		public async Task<ActionResult<Job>> AddJob(Job job)
		{
			await _repository.AddJob(job);

			return CreatedAtRoute("GetJob", new { id = job.Id.ToString() }, job);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteJob(string id)
		{
			var job = await _repository.GetJobById(id);

			if (job == null)
			{
				return NotFound();
			}

			var isDeleted = await _repository.DeleteJob(id);

			if (isDeleted)
			{
				return NoContent();
			}

			return StatusCode(500);
		}



	}
}
