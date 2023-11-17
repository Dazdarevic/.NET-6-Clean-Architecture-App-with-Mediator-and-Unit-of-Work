using AutoMapper;
using MediatR;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{
    public class GetMemberCommentsHandler : IRequestHandler<GetMemberCommentsQuery, IEnumerable<MemberComment>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetMemberCommentsHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MemberComment>> Handle(GetMemberCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await uow.MemberRepository.GetMemberCommentsAsync(request.MemberId);
            return mapper.Map<IEnumerable<MemberComment>>(comments);
        }
    }
}
