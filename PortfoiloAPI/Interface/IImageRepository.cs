

using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Interface
{
    public interface IImageRepository
    {
        Task<Image> AddImageAsync(ImageDTO imageDTO);

        Task<bool> DeleteImageAsync(Guid imgID);

        Task<bool> DeleteImageByProjectIDAsync(Guid projectID);

        Task<List<Image>> GetImagesAsync();
    }
}
