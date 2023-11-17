using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries
{
    public class SortTrainersQuery : IRequest<IEnumerable<TrainerUser>>
    {
        public string? SortByField { get; set; }
    }

}
