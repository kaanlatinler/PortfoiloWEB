using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortfoiloWEB.Areas.Admin.DTO;
using PortfoiloWEB.Areas.Admin.Services;
using PortfoiloWEB.Models;
using PortfoiloWEB.ViewModels;
using System.Diagnostics;

namespace PortfoiloWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiServices _apiServices;

        public HomeController(ILogger<HomeController> logger, ApiServices apiServices)
        {
            _logger = logger;
            _apiServices = apiServices;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _apiServices.GetCategoriesAsync();
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
            }).ToList();

            var viewModel = new PageViewModel
            {
                Projects = projectList,
                Categories = categories.ToList(),
            };
            return View(viewModel);
        }

        public async Task<IActionResult> ProjectDetails(Guid projectID)
        {
            var categories = await _apiServices.GetCategoriesAsync();
            var languages = await _apiServices.GetLanguagesAsync();
            var projects = await _apiServices.GetProjectsAsync();
            var images = await _apiServices.GetImagesAsync();

            var projectList = projects.Where(p=>p.ProjectId == projectID).Select(p => new IndexPageViewModel
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
                Language = languages.FirstOrDefault(l=>l.LangId == p.ProjectLangId),
            }).ToList();

            var viewModel = new PageViewModel
            {
                Projects = projectList,
                Categories = categories.ToList(),
                Languages = languages.ToList(),
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Contact(PageViewModel model)
        {
            await _apiServices.AddContactAsync(model.contact);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
