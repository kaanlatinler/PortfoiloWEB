using Microsoft.AspNetCore.Mvc;
using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Interface;
using PortfoiloAPI.Mappers.Language;

namespace PortfoiloAPI.Controllers.Admin
{
    [Route("api/Admin/Language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageController(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        [HttpPost("Add")]
        public async Task<IActionResult>  Add([FromBody] LanguageDTO langDTO)
        {
           await _languageRepository.AddLanguageAsync(langDTO);
           return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid langID)
        {
            bool isDeleted = await _languageRepository.DeleteLanguageAsync(langID);

            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var languages = await _languageRepository.GetLanguagesAsync();

            return Ok(languages);
        }
    }
}
