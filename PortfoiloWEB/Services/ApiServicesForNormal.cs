using Microsoft.AspNetCore.Http.HttpResults;
using PortfoiloWEB.DTO;
using PortfoiloWEB.ViewModels;
using PortfoiloWEB.Models;

namespace PortfoiloWEB.Services
{
    public class ApiServicesForNormal
    {
        private readonly HttpClient _httpClient;

        public ApiServicesForNormal(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<LanguageDTO>?> GetLangAsync()
        {
            string url = "https://localhost:7093/api/Admin/Language/List";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var languages = await response.Content.ReadFromJsonAsync<List<LanguageDTO>>();
                return languages;
            }

            return null;
        }

        public async Task<List<CategoryDTO>?> GetCategoryAsync()
        {
            string url = "https://localhost:7093/api/Admin/Category/List";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadFromJsonAsync<List<CategoryDTO>>();
                return categories;
            }

            return null;
        }

        public async Task<List<Project>?> GetProjectAsync()
        {
            string url = "https://localhost:7093/api/Admin/Project/List";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var projects = await response.Content.ReadFromJsonAsync<List<Project>>();
                return projects;
            }

            return null;
        }

        public async Task<List<ImageDTO>?> GetImageAsync()
        {
            string url = "https://localhost:7093/api/Admin/Image/List";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var image = await response.Content.ReadFromJsonAsync<List<ImageDTO>>();
                return image;
            }

            return null;
        }
    }
}
