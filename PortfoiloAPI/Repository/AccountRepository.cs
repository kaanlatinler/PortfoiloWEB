using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Interface;
using PortfoiloAPI.Mappers.Language;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {

        private readonly PortfoiloDbContext _db;

        public AccountRepository(PortfoiloDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckUserExistAsync(string Username, string Pass)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == Username && u.Password == Pass);

            if(user != null)
            {
                return true;
            }
            return false;
        }
    }
}
