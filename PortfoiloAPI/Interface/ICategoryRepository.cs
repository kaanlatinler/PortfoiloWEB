

using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategoryAsync(CategoryDTO category);

        Task<bool> DeleteCategoryAsync(Guid catID);

        Task<List<Category>> GetCategoriesAsync();
    }
}
