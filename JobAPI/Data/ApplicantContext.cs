using JobAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace JobAPI.Data
{
	public class ApplicantContext
	{
		public ApplicantContext(IConfiguration configuration)
		{
			var client = new MongoClient(configuration["DataBaseSettings2:ConnectionString"]);
			var database = client.GetDatabase(configuration["DataBaseSettings2:DatabaseName"]);
			applicant = database.GetCollection<Applicant>(configuration["DataBaseSettings2:CollectionName"]);
			seedData(applicant);
		}
		public IMongoCollection<Applicant> applicant { get; }
		public static void seedData(IMongoCollection<Applicant> blogsCollection)
		{
			bool existBlog = blogsCollection.Find(b => true).Any();
			if (!existBlog)
			{
				blogsCollection.InsertMany(GetPreconfBlogs());
			}
		}
		private static IEnumerable<Applicant> GetPreconfBlogs()
		{
			return new List<Applicant>()
			{
				new Applicant () {



						  }
			};
		}
	}
}
