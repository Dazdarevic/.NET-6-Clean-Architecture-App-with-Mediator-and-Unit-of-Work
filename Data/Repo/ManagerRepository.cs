using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Data.Repo
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly DataContext dc;

        public ManagerRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<TrainerUser>> GetAllTrainersAsync()
        {
            return await dc.Trainers.ToListAsync();
        }

        public async Task AddTrainerSalaryAsync(int trainerId, string salaryAmount)
        {
            var trainer = await dc.Trainers.FindAsync(trainerId);
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (trainer != null)
            {
                var trainerSalary = new TrainerSalary
                {
                    ID = trainerId,
                    SalaryAmount = salaryAmount
                };
                dc.TrainerSalaries.Add(trainerSalary);
            }
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
        }

        public async Task AddMembershipAmount(int memberId, string membershipAmount)
        {
            var member =  await dc.Members.FindAsync(memberId);
            if(member!=null)
            {
                var membership = new Membership
                {
                    ID = memberId,
                    MembershipAmount = membershipAmount
                };

                dc.Memberships.Add(membership);
            }
        }

        public async Task<int> GetTrainerIdOccurrenceAsync(int trainerId)
        {
            int numberOfMembers = await dc.Members.CountAsync(m => m.SelectedTrainerId == trainerId);
            return numberOfMembers;
        }

    }
}
