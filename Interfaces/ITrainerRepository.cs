using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Interfaces
{
    public interface ITrainerRepository
    {
        //pregled liste clanova
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<IEnumerable<Member>> GetMembersWithSelectedTrainerAsync(int trainerId);
        Task<bool> AddCommentAsync(Comment comment);
        Task<bool> UpdateCommentTextAsync(int commentId, string newText);    }
}
