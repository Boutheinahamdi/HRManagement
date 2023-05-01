using Azure.Storage.Blobs;
using JobAPI.Models;
using JobAPI.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace JobAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppliquantController : Controller
	{
		private readonly IAppliquant _applicant;
		private readonly IWebHostEnvironment _environment;
        private readonly BlobServiceClient _blobServiceClient;

        public AppliquantController(IAppliquant applicant, IWebHostEnvironment environment, BlobServiceClient blobServiceClient)
        {
            _applicant=applicant;
			_environment = environment;
            _blobServiceClient = blobServiceClient;

        }
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Applicant>>> GetAppls()
		{
			var appls = await _applicant.GetAppliquants();
			return Ok(appls);
		}

		[HttpGet("{id}", Name = "GetAppl")]
		public async Task<ActionResult<Applicant>> GetApplById(string id)
		{
			var appl = await _applicant.GetAppliquantById(id);

			if (appl == null)
			{
				return NotFound();
			}

			return Ok(appl);
		}


        [HttpPost]
        public async Task<ActionResult<Applicant>> Create([FromForm] Applicant applicant)
        {
            // Get a reference to the container
            BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient("blobscontainer");

            // Save the uploaded file to Azure Blob Storage
            if (applicant.Cv != null && applicant.Cv.Length > 0)
            {
                // Specify a unique name for the blob
                string blobName = $"{Guid.NewGuid()}{Path.GetExtension(applicant.Cv.FileName)}";

                // Upload the blob
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                await blobClient.UploadAsync(applicant.Cv.OpenReadStream(), overwrite: true);

                // Save the blob URI
                applicant.CvPath = blobClient.Uri.ToString();
            }

            // Save the applicant object to the database
            await _applicant.AddAppliquant(applicant);
            return CreatedAtRoute("GetAppl", new { id = applicant.ID }, applicant);
        }





        [HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAppl(string id)
		{
			var appl = await _applicant.GetAppliquantById(id);

			if (appl == null)
			{
				return NotFound();
			}

			var isDeleted = await _applicant.DeleteAppliquant(id);

			if (isDeleted)
			{
				return NoContent();
			}

			return StatusCode(500);
		}
	}
}
