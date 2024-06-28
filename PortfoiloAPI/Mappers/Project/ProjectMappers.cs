using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Mappers.Category;
using PortfoiloAPI.Mappers.Image;
using PortfoiloAPI.Mappers.Language;

namespace PortfoiloAPI.Mappers.Project
{
    public static class ProjectMappers
    {
        public static Models.Project ToProjectFromProjectDTO(this ProjectDTO model)
        {
            Guid proID = Guid.NewGuid();

            return new Models.Project
            {
                ProjectUrl = model.ProjectUrl,
                ProjectName = model.ProjectName,
                ProjectLangID = model.ProjectLangID,
                ProjectImgID = model.ProjectImgID,
                ProjectID = proID,
                ProjectDesc = model.ProjectDesc,
                ProjectCatID = model.ProjectCatID,
                ProjectClient = model.ProjectClient,
                ProjectDate = model.ProjectDate,
            };
        }
    }
}
