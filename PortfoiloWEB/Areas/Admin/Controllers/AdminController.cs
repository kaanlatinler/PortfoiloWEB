using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfoiloWEB.Areas.Admin.DTO;
using PortfoiloWEB.Areas.Admin.Services;
using System.Security.Claims;
using PortfoiloWEB.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfoiloWEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApiServices _apiServices;

        public AdminController(IWebHostEnvironment webHostEnvironment, ApiServices apiServices)
        {
            _webHostEnvironment = webHostEnvironment;
            _apiServices = apiServices;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Admin", new { area = "Admin" });
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _apiServices.GetCategoriesAsync();
            var languages = await _apiServices.GetLanguagesAsync();
            var projects = await _apiServices.GetProjectsAsync();
            var images = await _apiServices.GetImagesAsync();

            var projectList = projects.Select(p => new IndexPageViewModel
            {
                Project = new ProjectDTO
                {
                    ProjectCatId = p.ProjectCatId,
                    ProjectClient = p.ProjectClient,
                    ProjectDate = p.ProjectDate,
                    ProjectDesc = p.ProjectDesc,
                    ProjectId = p.ProjectId,
                    ProjectImgId = p.ProjectImgId,
                    ProjectLangId = p.ProjectLangId,
                    ProjectName = p.ProjectName,
                    ProjectUrl = p.ProjectUrl,
                },
                Category = categories.FirstOrDefault(c => c.CategoryId == p.ProjectCatId),
                Images = images.Where(i => i.ImageId == p.ProjectImgId).ToList(),
                Language = languages.FirstOrDefault(l => l.LangId == p.ProjectLangId),
            }).ToList();

            var viewModel = new PageViewModel
            {
                Projects = projectList,
                Categories = new SelectList(categories, "CategoryId", "CategoryName"),
                Languages = new SelectList(languages, "LangId", "LangName"),
                NewProject = new ProjectDTO()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Contact()
        {
            var contacts = await _apiServices.GetContactsAsync();
            

            return View(contacts.ToList());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserDTO user)
        {
            var result = await _apiServices.Login(user);

            if (result != null)
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                ClaimsIdentity CI = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties prop = new AuthenticationProperties
                {
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(CI), prop);

                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            return RedirectToAction("Login", "Admin", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(PageViewModel model)
        {
            var result = await _apiServices.AddProjectAsync(model.NewProject);

            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            foreach (var image in model.pics)
            {
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                string filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                var img = new ImageDTO
                {
                    ImageId = Guid.NewGuid(),
                    ImgPath = $"/images/{fileName}",
                    ProjectId = result.ProjectId,
                };

                await _apiServices.AddImageAsync(img);
            }

            return RedirectToAction("Index", "Admin", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(IndexPageViewModel model)
        {
            await _apiServices.AddCategoryAsync(model.Category);
            return RedirectToAction("Index", "Admin", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> AddLang(IndexPageViewModel model)
        {
            await _apiServices.AddLanguageAsync(model.Language);
            return RedirectToAction("Index", "Admin", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProject(Guid projectID)
        {
            await _apiServices.DeleteProjectAsync(projectID);

            return RedirectToAction("Index", "Admin", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContact(Guid contactID)
        {
            await _apiServices.DeleteContactAsync(contactID);

            return RedirectToAction("Contact", "Admin", new { area = "Admin" });
        }
    }
}
