using Microsoft.AspNetCore.Mvc;
using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Interface;
using PortfoiloAPI.Mappers.User;

namespace PortfoiloAPI.Controllers.Admin
{
    [Route("api/Admin/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromQuery] UserDTO userDTO)
        {
            var user = userDTO.ToUser();

            if(await _accountRepository.CheckUserExistAsync(user.UserName, user.Password))
            {
                return Ok(user);
            }

            return NotFound();
        }
    }
}
