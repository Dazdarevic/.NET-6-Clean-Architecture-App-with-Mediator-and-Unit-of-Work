using Microsoft.AspNetCore.Mvc;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Interfaces
{
    public interface IManagerRepository
    {
        Task<IEnumerable<TrainerUser>> GetAllTrainersAsync();
        Task<int> GetTrainerIdOccurrenceAsync(int trainerId);

        Task AddTrainerSalaryAsync(int trainerId, string salaryAmount);
        Task AddMembershipAmount(int memberId, string membershipAmount);

    }
}
