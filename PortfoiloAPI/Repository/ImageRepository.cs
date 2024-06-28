using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using PortfoiloAPI.DTO.Admin;
using PortfoiloAPI.Interface;
using PortfoiloAPI.Mappers.Image;
using PortfoiloAPI.Mappers.Language;
using PortfoiloAPI.Mappers.Project;
using PortfoiloAPI.Models;

namespace PortfoiloAPI.Repository
{
    public class ImageRepository : IImageRepository
    {

        private readonly PortfoiloDbContext _db;

        public ImageRepository(PortfoiloDbContext db)
        {
            _db = db;
        }

        public async Task<Image?> AddImageAsync(ImageDTO imageDTO)
        {
            var image = imageDTO.ToImgFromImgDTO();

            await _db.Images.AddAsync(image);
            var result = await _db.SaveChangesAsync();

            if (result > 0)
            {
                return image;
            }

            return null;
        }

        public async Task<bool> DeleteImageAsync(Guid imgID)
        {
            var images = await _db.Images.FindAsync(imgID);
            _db.Images.Remove(images);
            var result = await _db.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteImageByProjectIDAsync(Guid projectID)
        {
            var img = await _db.Images.FirstOrDefaultAsync(i => i.ProjectID == projectID);
            _db.Images.Remove(img);
            var result = await _db.SaveChangesAsync();
            if(result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<Image>> GetImagesAsync()
        {
            var images = await _db.Images.ToListAsync();
            return images;
        }
    }
}
