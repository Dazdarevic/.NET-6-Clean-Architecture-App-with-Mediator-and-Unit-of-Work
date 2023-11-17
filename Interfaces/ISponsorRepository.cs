using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Interfaces
{
    public interface ISponsorRepository
    {
        void AddAd(Advertisement ad);
        Task<IEnumerable<Advertisement>> GetAllAdsAsync();


    }
}
