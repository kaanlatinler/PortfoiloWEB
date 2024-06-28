using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Mappers.Image
{
    public static class ImageMappers
    {
        public static Models.Image ToImgFromImgDTO(this ImageDTO model)
        {
            return new Models.Image
            {
                ImageID = Guid.NewGuid(),
                ImgPath = model.ImgPath,
                ProjectID = model.ProjectID,
            };
        }
    }
}
