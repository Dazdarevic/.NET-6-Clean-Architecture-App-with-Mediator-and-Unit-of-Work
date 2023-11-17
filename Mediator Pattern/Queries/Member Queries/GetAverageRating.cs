using MediatR;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries
{
    public class GetAverageRating : IRequest<double>
    {
        public int TrainerId { get; set; }

    }
}
