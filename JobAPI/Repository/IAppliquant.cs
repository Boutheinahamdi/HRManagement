using JobAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobAPI.Repository
{
	public interface IAppliquant
	{
       	
		Task<IEnumerable<Applicant>> GetAppliquants();

		Task<Applicant> GetAppliquantById(string id);

		Task AddAppliquant(Applicant applicant);

		Task<bool> DeleteAppliquant(string id);
	}
}
