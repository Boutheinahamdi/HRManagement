using JobAPI.Data;
using JobAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobAPI.Repository
{
	public class JobImplement : Igeneric
	{
		private readonly JobContext _context;

		public JobImplement( JobContext context)
        {
			_context = context;
        }
        public async Task AddJob(Job job)
		{
			job.Id = ObjectId.GenerateNewId().ToString();
			await _context.job.InsertOneAsync(job);
		}

		public async Task<bool> DeleteJob(string id)
		{
			var deleteResult = await _context.job.DeleteOneAsync(job => job.Id == id);

			return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
		}

		public async Task<Job> GetJobById(string id)
		{
			return await _context.job.Find<Job>(job => job.Id == id).FirstOrDefaultAsync();

		}

		public async Task<IEnumerable<Job>> GetJobs()
		{
			return await _context.job.Find(project => true).ToListAsync();

		}
	}
}
