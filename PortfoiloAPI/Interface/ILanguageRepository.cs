

using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Interface
{
    public interface ILanguageRepository
    {
        Task<Language> AddLanguageAsync(LanguageDTO language);

        Task<bool> DeleteLanguageAsync(Guid langID);

        Task<List<Language>> GetLanguagesAsync();
    }
}
