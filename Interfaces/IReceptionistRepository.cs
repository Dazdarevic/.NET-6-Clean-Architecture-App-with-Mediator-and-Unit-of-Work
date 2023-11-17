using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Interfaces
{
    public interface IReceptionistRepository
    {
        Task<bool> CreateRegistrationRequestAsync(RegistrationRequest request);
        Task<IEnumerable<RegistrationRequest>> GetAllRequestsAsync();
        Task<bool> ApproveRegistrationRequestAsync(int requestId);
        Task<bool> DeleteRequestAsync(int requestId);


    }
}
