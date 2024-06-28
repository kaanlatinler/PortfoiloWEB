using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Interface;
using PortfoiloAPI.Mappers.Language;
using PortfoiloAPI.Mappers.Project;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Repository
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly PortfoiloDbContext _db;

        public ProjectRepository(PortfoiloDbContext db)
        {
            _db = db;
        }

        public async Task<Project?> AddProjectAsync(ProjectDTO projectDTO)
        {
            var project = projectDTO.ToProjectFromProjectDTO();

            await _db.Projects.AddAsync(project);
            var result = await _db.SaveChangesAsync();

            if (result > 0)
            {
                return project;
            }

            return null;
        }

        public async Task<bool> DeleteProjectAsync(Guid projectID)
        {
            var project = await _db.Projects.FindAsync(projectID);
            _db.Projects.Remove(project);
            var result = await _db.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            var projects = _db.Projects.ToList();

            return projects;
        }

        public async Task<bool> UpdateProjectImgAsync(Guid projectID, Guid imgID)
        {
            var project = await _db.Projects.FindAsync(projectID);
            project.ProjectImgID = imgID;
            _db.Projects.Update(project);
            var result = await _db.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }

            return false;
        }
    }
}
