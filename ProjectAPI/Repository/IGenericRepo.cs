using ProjectAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPI.Repository
{
    public interface IGenericRepo
    {
        Task<IEnumerable<Project>> GetProjects();

        Task<Project> GetProjectById(string id);

        Task AddProject(Project project);

        Task<bool> DeleteProject(string id);
    }
}
