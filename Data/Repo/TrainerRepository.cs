using Microsoft.EntityFrameworkCore;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Data.Repo
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly DataContext dc;

        public TrainerRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            var members = await dc.Members.ToListAsync();

            return members;
        }

        public async Task<IEnumerable<Member>> GetMembersWithSelectedTrainerAsync(int trainerId)
        {
            var membersWithSelectedTrainer = await dc.Members
                .Where(member => member.SelectedTrainerId == trainerId)
                .ToListAsync();

            return membersWithSelectedTrainer;
        }

        public async Task<bool> AddCommentAsync(Comment comment)
        {
            var member = await dc.Members.FindAsync(comment.MemberId);
            var trainer = await dc.Trainers.FindAsync(comment.TrainerId);

            if (member != null && trainer != null)
            {
                var newcomment = new Comment
                {
                    Text = comment.Text,
                    MemberId = comment.MemberId,
                    TrainerId = comment.TrainerId
                };

                dc.Comments.Add(newcomment);

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateCommentTextAsync(int commentId, string newText)
        {
            var comment = await dc.Comments.FindAsync(commentId);

            if (comment != null)
            {
                comment.Text = newText;
                return true;
            }

            return false;
        }
    }
}
