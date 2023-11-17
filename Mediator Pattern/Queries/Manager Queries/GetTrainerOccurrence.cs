using MediatR;

namespace Napredne_baze_podataka_API.Queries.Manager_Queries
{
    public class GetTrainerOccurrenceQuery : IRequest<int>
    {
        public int TrainerId { get; }

        public GetTrainerOccurrenceQuery(int trainerId)
        {
            TrainerId = trainerId;
        }
    }
}
