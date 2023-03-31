using EmployeeApi.Data;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

namespace EmployeeApi.Repository
{
    public class EmployeLogiccs : IrepositoryEmploye
    {
        private readonly EmployeContext _context;

        public EmployeLogiccs( EmployeContext context)
        {
            _context = context;
        }
        public void AddEmploye(Employee employe)
        {
           _context.employe.InsertOne(employe);
           
        }

        public void DeleteEmploye(string id)
        {
            _context.employe.DeleteOne(id); 
        }

        public IEnumerable<Employee> GetAll()
        {
          return _context.employe.Find(emp => true).ToList();
        }

        public Employee GetById(string id)
        {
            Employee emp =  _context.employe.Find(emp => emp.ID == id).FirstOrDefault();

            return emp;
        }

        
    }
}
