using MediatR;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries
{
    public class GetHasSelectedTrainerQuery : IRequest<bool>
    {
        public int MemberId { get; set; } 
    }
}
