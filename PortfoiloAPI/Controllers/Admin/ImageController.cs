using Microsoft.AspNetCore.Mvc;
using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Interface;
using PortfoiloAPI.Repository;

namespace PortfoiloAPI.Controllers.Admin
{
    [Route("api/Admin/Image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IProjectRepository _projectRepository;

        public ImageController(IImageRepository imageRepository, IProjectRepository projectRepository)
        {
            _imageRepository = imageRepository;
            _projectRepository = projectRepository;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ImageDTO imageDTO)
        {
            var img = await _imageRepository.AddImageAsync(imageDTO);
            var updated = await _projectRepository.UpdateProjectImgAsync(img.ProjectID, img.ImageID);
            if (img == null || !updated)
            {
                return BadRequest();
            }
            return Ok(img);
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var images = await _imageRepository.GetImagesAsync();

            return Ok(images);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid imgID)
        {
            bool isDeleted = await _imageRepository.DeleteImageAsync(imgID);

            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
