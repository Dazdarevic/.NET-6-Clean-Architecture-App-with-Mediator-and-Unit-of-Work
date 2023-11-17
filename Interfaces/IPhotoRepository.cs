using CloudinaryDotNet.Actions;

namespace Napredne_baze_podataka_API.Interfaces
{
    public interface IPhotoRepository
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

    }
}
