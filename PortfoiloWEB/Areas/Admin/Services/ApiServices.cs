using Microsoft.AspNetCore.Http.HttpResults;
using PortfoiloWEB.Areas.Admin.DTO;
using PortfoiloWEB.Areas.Admin.ViewModels;
using PortfoiloWEB.Models;

namespace PortfoiloWEB.Areas.Admin.Services
{
    public class ApiServices
    {
        private readonly HttpClient _httpClient;

        public ApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User?> Login(UserDTO user)
        {
            string url = $"https://localhost:7093/api/Admin/Account/Login?UserName={user.UserName}&Password={user.Password}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadFromJsonAsync<User>();
                return users;
            }

            return null;
        }

        public async Task<List<LanguageDTO>?> GetLanguagesAsync()
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

        public async Task<List<CategoryDTO>?> GetCategoriesAsync()
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

        public async Task<List<Project>?> GetProjectsAsync()
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

        public async Task<List<ContactDTO>?> GetContactsAsync()
        {
            string url = "https://localhost:7093/api/Admin/Contact/List";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var contacts = await response.Content.ReadFromJsonAsync<List<ContactDTO>>();
                return contacts;
            }

            return null;
        }

        public async Task<List<ImageDTO>?> GetImagesAsync()
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

        public async Task<bool> AddCategoryAsync(CategoryDTO category)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7093/api/Admin/Category/Add", category);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddContactAsync(ContactDTO contact)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7093/api/Admin/Contact/Add", contact);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddLanguageAsync(LanguageDTO language)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7093/api/Admin/Language/Add", language);

            return response.IsSuccessStatusCode;
        }

        public async Task<ProjectDTO?> AddProjectAsync(ProjectDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7093/api/Admin/Project/Add", model);

            if (response.IsSuccessStatusCode)
            {
                var projectResponse = await response.Content.ReadFromJsonAsync<ProjectDTO>();
                return projectResponse;
            }
            return null;
        }

        public async Task<bool> AddImageAsync(ImageDTO image)
        {
            var response = await _httpClient.PostAsJsonAsync($"https://localhost:7093/api/Admin/Image/Add", image);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProjectAsync(Guid projectID)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7093/api/Admin/Project/Delete?projectID={projectID}");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteContactAsync(Guid contactID)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7093/api/Admin/Contact/Delete?contactID={contactID}");

            return response.IsSuccessStatusCode;
        }
    }
}
