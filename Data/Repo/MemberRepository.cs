using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Data.Repo
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataContext dc;

        public MemberRepository(DataContext dc)
        {
            this.dc = dc;
        }


        public async Task<IEnumerable<TrainerUser>> SortTrainersAsync(string sortByField)
        {
            if (sortByField == "firstName")
            {
                return await dc.Trainers.OrderBy(t => t.FirstName).ToListAsync();
            }
            else if (sortByField == "lastName")
            {
                return await dc.Trainers.OrderBy(t => t.LastName).ToListAsync();
            }
            return null;
        }


        public async Task<bool> ChooseTrainer(int memberId, int trainerId)
        {
            var member = await dc.Members.FindAsync(memberId);
            if (member != null && member.SelectedTrainerId == null)
            {
                member.SelectedTrainerId = trainerId;
                return true;
            }
            return false;
        }


        public async Task<bool> ResetSelectedTrainer(int memberId)
        {
            var member = await dc.Members.FindAsync(memberId);
            if (member != null)
            {
                member.SelectedTrainerId = null;
                return true;
            }
            return false;
        }
        
        public async Task<bool> CheckRating(int memberId, int trainerId)
        {
            var rating = await dc.Ratings.FirstOrDefaultAsync(r => r.MemberId == memberId && r.TrainerId == trainerId);

            return rating != null;
        }

        public async Task<IEnumerable<Membership>> GetMembershipsForMemberAsync(int memberId)
        {
            return await dc.Memberships.Where(m => m.ID == memberId).ToListAsync();
        }

        public async Task<IEnumerable<TrainerUser>> GetAllTrainersAsync()
        {
            return await dc.Trainers.ToListAsync();
        }

        public async Task<Member> GetMember(int memberId)
        {
            var member = await dc.Members.FindAsync(memberId);
#pragma warning disable CS8603 // Possible null reference return.
            return member;
#pragma warning restore CS8603 // Possible null reference return.
        }
        public async Task<TrainerUser> GetTrainer(int trainerId)
        {
            var trainer = await dc.Trainers.FindAsync(trainerId);

#pragma warning disable CS8603 // Possible null reference return.
            return trainer;
#pragma warning restore CS8603 // Possible null reference return.
        }
        public async Task<bool> ExtendMembershipAsync(int memberId, string newMembershipAmount, int targetMonth)
        {
            var member = await dc.Memberships.FindAsync(memberId);

            if (member != null && targetMonth > DateTime.Now.Month) // Provera da li se produžava za naredni mesec
            {
                // Update membership details
                member.MembershipAmount = newMembershipAmount;
                member.Month = targetMonth;

                return true;
            }

            return false;
        }

        public async Task<bool> RateTrainerAsync(int memberId, int trainerId, int ratingValue)
        {
            var member = await dc.Members.FindAsync(memberId);
            var trainer = await dc.Trainers.FindAsync(trainerId);

            if (member != null && trainer != null && ratingValue >= 1 && ratingValue <= 5)
            {
                var rating = new Rating
                {
                    Value = ratingValue,
                    MemberId = memberId,
                    TrainerId = trainerId
                };

                dc.Ratings.Add(rating);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Comment>> GetMemberCommentsAsync(int memberId)
        {
            var comments = await dc.Comments
                .Where(comment => comment.MemberId == memberId)
                .ToListAsync();

            return comments;
        }

        public async Task<bool> HasSelectedTrainer(int memberId)
        {
            var member = await dc.Members.FindAsync(memberId);

            if (member != null && member.SelectedTrainerId.HasValue && member.SelectedTrainerId != -1)
            {
                return true;
            }

            return false;
        }


        public async Task<double> GetAverageRatingByTrainerId(int trainerId)
        {
                double averageRating = await dc.Ratings
                    .Where(r => r.TrainerId == trainerId)
                    .AverageAsync(r => r.Value);

                return averageRating;
            
        }

        public async Task<IEnumerable<TrainerUser>> GetPaginatedTrainersAsync(int page, int pageSize)
        {
            var trainers = await dc.Trainers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return trainers;
        }

    }
}
