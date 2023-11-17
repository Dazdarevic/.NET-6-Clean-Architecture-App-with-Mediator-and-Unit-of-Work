using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{
    public class GetMembershipsForMemberHandler : IRequestHandler<GetMembershipsForMemberQuery, IEnumerable<Membership>>
    {
        private readonly IUnitOfWork uow;

        public GetMembershipsForMemberHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<Membership>> Handle(GetMembershipsForMemberQuery request, CancellationToken cancellationToken)
        {
            return await uow.MemberRepository.GetMembershipsForMemberAsync(request.MemberId);
        }
    }
}
