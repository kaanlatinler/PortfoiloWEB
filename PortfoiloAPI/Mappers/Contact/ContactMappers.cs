using PortfoiloAPI.DTO.Admin;

namespace PortfoiloAPI.Mappers.Contact
{
    public static class ContactMappers
    {
        public static Models.Contact ToContactFromDTO(this ContactDTO model)
        {
            return new Models.Contact
            {
                ContactID = Guid.NewGuid(),
                Email = model.Email,
                Message = model.Message,
                Name = model.Name,
                Subject = model.Subject,
            };
        }
    }
}
