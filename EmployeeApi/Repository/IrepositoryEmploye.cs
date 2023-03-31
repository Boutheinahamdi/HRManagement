using EmployeeApi.Models;
using System.Collections.Generic;

namespace EmployeeApi.Repository
{
    public interface IrepositoryEmploye
    {
        public IEnumerable<Employee> GetAll();
   
        public Employee GetById(string id);
        public void AddEmploye(Employee employe);
      
        public void DeleteEmploye(string id);
    }
}
