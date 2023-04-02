using EmployeeApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace EmployeeApi.Data
{
	public class DepartementContext
	{

		public DepartementContext(IConfiguration configuration)
		{
			var client = new MongoClient(configuration["DataBaseSettings3:ConnectionString"]);
			var database = client.GetDatabase(configuration["DataBaseSettings3:DatabaseName"]);
			departement = database.GetCollection<Departement>(configuration["DataBaseSettings3:CollectionName"]);
			seedData(departement);
		}
		public IMongoCollection<Departement> departement { get; }
		public static void seedData(IMongoCollection<Departement> blogsCollection)
		{
			bool existBlog = blogsCollection.Find(b => true).Any();
			if (!existBlog)
			{
				blogsCollection.InsertMany(GetPreconfBlogs());
			}
		}
		private static IEnumerable<Departement> GetPreconfBlogs()
		{
			return new List<Departement>()
			{
				new Departement() {



						  }
			};
		}
	}
}
