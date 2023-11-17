using Microsoft.Extensions.Options;
using Napredne_baze_podataka_API.Data.Repo;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        private readonly IConfiguration _configuration;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        public UnitOfWork(DataContext dc, IConfiguration configuration, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            this.dc = dc;
            _configuration = configuration;
            _cloudinaryConfig = cloudinaryConfig;
        }
        public IAdministartorRepository AdministratorRepository
            => new AdministratorRepository(dc);
        public IManagerRepository ManagerRepository
            => new ManagerRepository(dc);
        public IMemberRepository MemberRepository
            => new MemberRepository(dc);
        public ITrainerRepository TrainerRepository
            => new TrainerRepository(dc);
        public IReceptionistRepository ReceptionistRepository
            => new ReceptionistRepository(dc);
        public IPhotoRepository PhotoRepository
            => new PhotoRepository(_cloudinaryConfig);
        public ILoginRepository LoginRepository
            => new LoginRepository(dc, _configuration);
        public ISellerRepository SellerRepository
            => new SellerRepository(dc);
        public ISponsorRepository SponsorRepository
            => new SponsorRepository(dc);
        public IEmailSenderRepository EmailSenderRepository
            => new EmailSenderRepository();
        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
