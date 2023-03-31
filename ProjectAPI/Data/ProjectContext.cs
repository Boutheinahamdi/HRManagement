using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProjectAPI.Models;
using System.Collections.Generic;

namespace ProjectAPI.Data
{
    public class ProjectContext
    {
        public ProjectContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DataBaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DataBaseSettings:DatabaseName"]);
            project = database.GetCollection<Project>(configuration["DataBaseSettings:CollectionName"]);
            seedData(project);
        }
        public IMongoCollection<Project> project { get; }
        public static void seedData(IMongoCollection<Project> blogsCollection)
        {
            bool existBlog = blogsCollection.Find(b => true).Any();
            if (!existBlog)
            {
                blogsCollection.InsertMany(GetPreconfBlogs());
            }
        }
        private static IEnumerable<Project> GetPreconfBlogs()
        {
            return new List<Project>()
            {
                new Project() {



                          }
            };
        }
    }
}
