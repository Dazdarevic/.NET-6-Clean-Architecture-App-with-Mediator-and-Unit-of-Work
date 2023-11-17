using Microsoft.AspNetCore.Mvc;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Interfaces
{
    public interface IAdministartorRepository
    {
        Task<IEnumerable<Administrator>> GetAdminsAsync(int currentAdminId);
        Task<IEnumerable<Receptionist>> GetReceptionistsAsync();
        Task<IEnumerable<ManagerS>> GetManagersAsync();
        void AddAdmin(Administrator administrator);
        void AddReceptionist(Receptionist receptionist);
        void AddManager(ManagerS manager);
        void DeleteAdmin(int ID);
        Task<IActionResult> GetAdmin(int ID);
    }
}
