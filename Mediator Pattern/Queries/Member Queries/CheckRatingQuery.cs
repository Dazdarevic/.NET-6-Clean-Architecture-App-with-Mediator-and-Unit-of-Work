using MediatR;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries
{
    public class CheckRatingQuery : IRequest<bool>
    {
        public int MemberId { get; }
        public int TrainerId { get; }

        public CheckRatingQuery(int memberId, int trainerId)
        {
            MemberId = memberId;
            TrainerId = trainerId;
        }
    }
}
