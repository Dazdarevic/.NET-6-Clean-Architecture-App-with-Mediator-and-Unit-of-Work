using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries
{
    public class GetMemberQuery : IRequest<Member>
    {
        public int MemberId { get; }

        public GetMemberQuery(int memberId)
        {
            MemberId = memberId;
        }
    }
}
