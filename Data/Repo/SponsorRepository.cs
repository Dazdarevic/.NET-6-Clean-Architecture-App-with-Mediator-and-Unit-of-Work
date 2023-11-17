using Microsoft.EntityFrameworkCore;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Data.Repo
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly DataContext dc;

        public SponsorRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddAd(Advertisement ad)
        {
            dc.Advertisements.Add(ad);
        }

        public async Task<IEnumerable<Advertisement>> GetAllAdsAsync()
        {
            return await dc.Advertisements.ToListAsync();
        }

    }
}
