using Microsoft.AspNetCore.Mvc.Rendering;
using PortfoiloWEB.Areas.Admin.DTO;

namespace PortfoiloWEB.Areas.Admin.ViewModels
{
    public class PageViewModel
    {
        public List<IndexPageViewModel> Projects { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Languages { get; set; }
        public ProjectDTO NewProject { get; set; }
        public List<IFormFile> pics { get; set; }
    }
}
