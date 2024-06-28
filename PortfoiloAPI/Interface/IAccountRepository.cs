

using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Interface
{
    public interface IAccountRepository
    {
        Task<bool> CheckUserExistAsync(string Username, string Pass);
    }
}
