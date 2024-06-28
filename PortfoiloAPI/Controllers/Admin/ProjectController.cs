using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Interface;
using PortfoiloAPI.Repository;
using System.Xml;

namespace PortfoiloAPI.Controllers.Admin
{
    [Route("api/Admin/Project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IImageRepository _imageRepository;

        public ProjectController(IProjectRepository projectRepository, IImageRepository imageRepository)
        {
            _projectRepository = projectRepository;
            _imageRepository = imageRepository;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ProjectDTO projectDTO)
        {
            var project = await _projectRepository.AddProjectAsync(projectDTO);
            return Ok(project);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid projectID)
        {
            bool isDeleted = await _projectRepository.DeleteProjectAsync(projectID);
            bool isImgDeleted = await _imageRepository.DeleteImageByProjectIDAsync(projectID);
            if (isDeleted && isImgDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var projects = await _projectRepository.GetProjectsAsync();

            return Ok(projects);
        }
    }
}
