using Microsoft.EntityFrameworkCore;
using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Interface;
using PortfoiloAPI.Mappers.Contact;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly PortfoiloDbContext _db;

        public ContactRepository(PortfoiloDbContext db)
        {
            _db = db;
        }

        public async Task<Contact?> AddContactAsync(ContactDTO contact)
        {
            var Contact = contact.ToContactFromDTO();
            await _db.Contacts.AddAsync(Contact);
            var result = await _db.SaveChangesAsync();

            if (result > 0)
            {
                return Contact;
            }

            return null;
        }

        public async Task<bool> DeleteContactAsync(Guid contactID)
        {
            var Contact = await _db.Contacts.FindAsync(contactID);
            _db.Contacts.Remove(Contact);
            var result = await _db.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            var contacts = await _db.Contacts.ToListAsync();
            return contacts;
        }
    }
}
