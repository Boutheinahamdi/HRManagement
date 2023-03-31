using EmployeeApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace EmployeeApi.Data
{
    public class EmployeContext
    {
        public EmployeContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DataBaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DataBaseSettings:DatabaseName"]);
            employe = database.GetCollection<Employee>(configuration["DataBaseSettings:CollectionName"]);
            seedData(employe);
        }
        public IMongoCollection<Employee> employe { get; }
        public static void seedData(IMongoCollection<Employee> blogsCollection)
        {
            bool existBlog = blogsCollection.Find(b => true).Any();
            if (!existBlog)
            {
                blogsCollection.InsertMany(GetPreconfBlogs());
            }
        }
        private static IEnumerable<Employee> GetPreconfBlogs()
        {
            return new List<Employee>()
            {
                new Employee() {

            

                          }
            };
        }
    }
}
