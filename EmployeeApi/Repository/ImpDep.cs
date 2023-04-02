using EmployeeApi.Data;
using EmployeeApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Repository
{
	public class ImpDep : IrepositoryEmploye
	{
		private readonly DepartementContext _context;

		public ImpDep( DepartementContext context)
        {
			_context = context;	
        }
        public async Task AddDepartement(Departement departement)
		{
			
			await _context.departement.InsertOneAsync(departement);
		}

		public async Task<bool> DeleteDepartement(string id)
		{

			var deleteResult = await _context.departement.DeleteOneAsync(dep => dep.ID == id);

			return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
		}

		public async Task<IEnumerable<Departement>> GetDepartments()
		{
			return await _context.departement.Find(dep => true).ToListAsync();
		}
	}
}
