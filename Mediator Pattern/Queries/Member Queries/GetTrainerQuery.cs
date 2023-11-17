using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries
{
    public class GetTrainerQuery : IRequest<TrainerUser>
    {
        public int TrainerId { get; }

        public GetTrainerQuery(int trainerId)
        {
            TrainerId = trainerId;
        }
    }
}
