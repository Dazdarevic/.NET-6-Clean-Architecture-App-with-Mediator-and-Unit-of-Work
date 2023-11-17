using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries
{
    public class GetMembershipsForMemberQuery : IRequest<IEnumerable<Membership>>
    {
        public int MemberId { get; set; }
    }
}
