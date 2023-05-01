using JobAPI.Data;
using JobAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobAPI.Repository
{
	public class AppliquantImpl : IAppliquant
	{
		private readonly ApplicantContext _context;

		public AppliquantImpl(ApplicantContext context)
		{
			_context = context;
		}
		public async Task AddAppliquant(Applicant applicant)
		{
			applicant.ID = ObjectId.GenerateNewId().ToString();
			await _context.applicant.InsertOneAsync(applicant);
		}

		public async Task<bool> DeleteAppliquant(string id)
		{
			var deleteResult = await _context.applicant.DeleteOneAsync(a => a.ID == id);

			return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
		}

		public async Task<Applicant> GetAppliquantById(string id)
		{
			return await _context.applicant.Find<Applicant>(appl => appl.ID == id).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Applicant>> GetAppliquants()
		{
			return await _context.applicant.Find(appl => true).ToListAsync();
		}
	}
}
