using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Mappers.Language
{
    public static class CategoryMappers
    {
        public static Models.Language ToLangFromlangDTO(this LanguageDTO model)
        {
            return new Models.Language
            {
                LangID = Guid.NewGuid(),
                LangName = model.LangName,
            };
        }
    }
}
