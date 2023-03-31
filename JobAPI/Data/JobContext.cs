﻿using JobAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace JobAPI.Data
{
	public class JobContext
	{
		public JobContext(IConfiguration configuration)
		{
			var client = new MongoClient(configuration["DataBaseSettings:ConnectionString"]);
			var database = client.GetDatabase(configuration["DataBaseSettings:DatabaseName"]);
			project = database.GetCollection<Job>(configuration["DataBaseSettings:CollectionName"]);
			seedData(project);
		}
		public IMongoCollection<Job> project { get; }
		public static void seedData(IMongoCollection<Job> blogsCollection)
		{
			bool existBlog = blogsCollection.Find(b => true).Any();
			if (!existBlog)
			{
				blogsCollection.InsertMany(GetPreconfBlogs());
			}
		}
		private static IEnumerable<Job> GetPreconfBlogs()
		{
			return new List<Job>()
			{
				new	Job	() {



						  }
			};
		}
	}
}
