

using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Interface
{
    public interface IProjectRepository
    {
        Task<Project> AddProjectAsync(ProjectDTO projectDTO);

        Task<bool> DeleteProjectAsync(Guid projectID);

        Task<bool> UpdateProjectImgAsync(Guid projectID, Guid imgID);

        Task<List<Project>> GetProjectsAsync();
    }
}
