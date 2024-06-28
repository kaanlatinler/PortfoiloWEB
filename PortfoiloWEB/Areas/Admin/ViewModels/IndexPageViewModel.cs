using Microsoft.AspNetCore.Mvc.Rendering;
using PortfoiloWEB.Areas.Admin.DTO;

namespace PortfoiloWEB.Areas.Admin.ViewModels
{
    public class IndexPageViewModel
    {
        public ProjectDTO Project { get; set; }
        public CategoryDTO Category { get; set; }
        public LanguageDTO Language { get; set; }
        public IEnumerable<ImageDTO> Images { get; set; }
    }
}
