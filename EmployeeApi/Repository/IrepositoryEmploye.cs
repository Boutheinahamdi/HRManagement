using EmployeeApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Repository
{
    public interface IrepositoryEmploye
    {
		Task<IEnumerable<Departement>> GetDepartments();


		Task AddDepartement(Departement departement);

		Task<bool> DeleteDepartement(string id);
	}
}
