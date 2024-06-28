using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Interface
{
    public interface IContactRepository
    {
        Task<Contact> AddContactAsync(ContactDTO contact);

        Task<bool> DeleteContactAsync(Guid contactID);

        Task<List<Contact>> GetContactsAsync();
    }
}
