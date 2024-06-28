using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Interface;
using PortfoiloAPI.Mappers.Category;
using PortfoiloAPI.Mappers.Language;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly PortfoiloDbContext _db;

        public CategoryRepository(PortfoiloDbContext db)
        {
            _db = db;
        }

        public async Task<Category?> AddCategoryAsync(CategoryDTO category)
        {
            var cat = category.ToCatFromCategoryDTO();
            await _db.Categories.AddAsync(cat);
            var result = await _db.SaveChangesAsync();

            if (result > 0)
            {
                return cat;
            }

            return null;
        }

        public async Task<bool> DeleteCategoryAsync(Guid catID)
        {
            var cat = await _db.Categories.FindAsync(catID);
            _db.Categories.Remove(cat);
            var result = await _db.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = await _db.Categories.ToListAsync();

            return categories;
        }
    }
}
