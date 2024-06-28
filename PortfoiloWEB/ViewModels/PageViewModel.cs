using Microsoft.AspNetCore.Mvc.Rendering;
using PortfoiloWEB.Areas.Admin.DTO;
using PortfoiloWEB.Models;

namespace PortfoiloWEB.ViewModels
{
    public class PageViewModel
    {
        public List<IndexPageViewModel> Projects { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<LanguageDTO> Languages { get; set; }
        public ContactDTO contact { get; set; }
    }
}
