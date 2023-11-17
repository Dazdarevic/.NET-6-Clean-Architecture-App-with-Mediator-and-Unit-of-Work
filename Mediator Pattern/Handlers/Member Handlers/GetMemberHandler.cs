using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{
    public class GetMemberHandler : IRequestHandler<GetMemberQuery, Member>
    {
        private readonly IUnitOfWork uow;

        public GetMemberHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<Member> Handle(GetMemberQuery request, CancellationToken cancellationToken)
        {
            return (Member)await uow.MemberRepository.GetMember(request.MemberId);
        }
    }
}
