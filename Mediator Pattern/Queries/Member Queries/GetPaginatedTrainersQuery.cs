using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries
{
    public class GetPaginatedTrainersQuery : IRequest<IEnumerable<TrainerUser>>
    {
        public int Page { get; }
        public int PageSize { get; }

        public GetPaginatedTrainersQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }

}
