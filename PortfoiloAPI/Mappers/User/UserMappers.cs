using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Mappers.User
{
    public static class UserMappers
    {
        public static Models.User ToUser(this UserDTO model)
        {
            return new Models.User
            {
                Password = model.Password,
                UserName = model.UserName,
            };
        }
    }
}
