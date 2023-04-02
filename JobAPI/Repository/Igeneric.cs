using JobAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobAPI.Repository
{
	public interface Igeneric
	{
		Task<IEnumerable<Job>> GetJobs();

		Task<Job> GetJobById(string id);

		Task AddJob(Job job);

		Task<bool> DeleteJob(string id);
	}
}
