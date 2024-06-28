using Microsoft.AspNetCore.Mvc;
using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Interface;
using PortfoiloAPI.Repository;

namespace PortfoiloAPI.Controllers.Admin
{
    [Route("api/Admin/Contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ContactDTO contactDTO)
        {
            var contact = await _contactRepository.AddContactAsync(contactDTO);
            if (contact == null)
            {
                return BadRequest();
            }
            return Ok(contact);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid contactID)
        {
            bool isDeleted = await _contactRepository.DeleteContactAsync(contactID);

            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var contacts = await _contactRepository.GetContactsAsync();

            return Ok(contacts);
        }
    }
}
