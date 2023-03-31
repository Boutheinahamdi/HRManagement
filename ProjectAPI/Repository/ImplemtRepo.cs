using ProjectAPI.Data;
using ProjectAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
namespace ProjectAPI.Repository
{
    public class ImplemtRepo : IGenericRepo
    {
        private readonly ProjectContext _context;

        public ImplemtRepo(ProjectContext context)
        {
            _context=context;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await _context.project.Find(project => true).ToListAsync();
        }

        public async Task<Project> GetProjectById(string id)
        {
            return await _context.project.Find<Project>(project => project.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddProject(Project project)
        {
            await _context.project.InsertOneAsync(project);
        }

        
       

        public async Task<bool> DeleteProject(string id)
        {
            var deleteResult = await _context.project.DeleteOneAsync(project => project.Id == id);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
