using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Member_Commands;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{
    public class ExtendMembershipHandler : IRequestHandler<ExtendMembershipCommand, bool>
    {
        private readonly IUnitOfWork uow;

        public ExtendMembershipHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(ExtendMembershipCommand request, CancellationToken cancellationToken)
        {
            return await uow.MemberRepository.ExtendMembershipAsync(request.MemberId, request.MembershipAmount, request.Month);
        }
    }
}
