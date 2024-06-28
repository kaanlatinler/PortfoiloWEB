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
    public class LanguageRepository : ILanguageRepository
    {

        private readonly PortfoiloDbContext _db;

        public LanguageRepository(PortfoiloDbContext db)
        {
            _db = db;
        }

        public async Task<Language?> AddLanguageAsync(LanguageDTO language)
        {
            var lang = language.ToLangFromlangDTO();
            await _db.Languages.AddAsync(lang);
            var result = await _db.SaveChangesAsync();

            if (result > 0)
            {
                return lang;
            }

            return null;
        }

        public async Task<bool> DeleteLanguageAsync(Guid langID)
        {
            var lang = await _db.Languages.FindAsync(langID);
            _db.Languages.Remove(lang);
            var result = await _db.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<List<Language>> GetLanguagesAsync()
        {
            var languages = await _db.Languages.ToListAsync();

            return languages;
        }
    }
}
