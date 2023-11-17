using Microsoft.AspNetCore.Mvc;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Interfaces
{
    public interface IMemberRepository
    {
        //pregled liste trenera
        Task<IEnumerable<TrainerUser>> GetAllTrainersAsync();

        //pregled licnih podataka
        Task<Member> GetMember(int memberId);
        Task<TrainerUser> GetTrainer(int trainerId);

        //biranje odgovarujuceg trenera
        Task<bool> ChooseTrainer(int memberId, int trainerId);
        Task<bool> CheckRating(int memberId, int trainerId);
        Task<bool> ResetSelectedTrainer(int memberId);
        Task<double> GetAverageRatingByTrainerId(int trainerId);
        Task<IEnumerable<TrainerUser>> GetPaginatedTrainersAsync(int page, int pageSize);


        //prikaz svih clanarina 
        Task<IEnumerable<Membership>> GetMembershipsForMemberAsync(int memberId);

        //produzenje clanarine za naredni mesec
        Task<bool> ExtendMembershipAsync(int memberId, string newMembershipAmount, int targetMonth);
        Task<IEnumerable<TrainerUser>> SortTrainersAsync(string sortByField);

        //ocenjivanje trenera ocenom od 1 do 5
        Task<bool> RateTrainerAsync(int memberId, int trainerId, int ratingValue);
        Task<bool> HasSelectedTrainer(int memberId);
        Task<IEnumerable<Comment>> GetMemberCommentsAsync(int memberId);
    }
}
