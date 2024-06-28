using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Mappers.Category
{
    public static class CategoryMappers
    {
        public static Models.Category ToCatFromCategoryDTO(this CategoryDTO model)
        {
            return new Models.Category
            {
                CategoryName = model.CategoryName,
                CategoryID = Guid.NewGuid(),
            };
        }
    }
}
