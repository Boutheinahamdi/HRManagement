using EmployeeApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using System.Collections.Generic;

namespace EmployeeApi.Data
{
	public class PostContext
	{
		public PostContext(IConfiguration configuration)
		{
			var client = new MongoClient(configuration["DataBaseSettings2:ConnectionString"]);
			var database = client.GetDatabase(configuration["DataBaseSettings2:DatabaseName"]);
			post = database.GetCollection<Postt>(configuration["DataBaseSettings2:CollectionName"]);
			seedData(post);
		}
		public IMongoCollection<Postt> post { get; }
		public static void seedData(IMongoCollection<Postt> blogsCollection)
		{
			bool existBlog = blogsCollection.Find(b => true).Any();
			if (!existBlog)
			{
				blogsCollection.InsertMany(GetPreconfBlogs());
			}
		}
		private static IEnumerable<Postt> GetPreconfBlogs()
		{
			return new List<Postt>()
			{
				new Postt() {



						  }
			};
		}
	}
}
