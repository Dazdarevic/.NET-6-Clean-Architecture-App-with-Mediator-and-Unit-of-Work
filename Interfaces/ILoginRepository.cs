using Microsoft.AspNetCore.Mvc;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Interfaces
{
    public interface ILoginRepository
    {
        Task<IActionResult> PostLoginDetails(UserData userData);
        string GenerateRefreshToken();

    }
}
