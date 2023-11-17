using MediatR;
using Napredne_baze_podataka_API.Commands.Manager_Commands;
using Napredne_baze_podataka_API.Interfaces;

namespace Napredne_baze_podataka_API.Handlers.Memberships
{
    public class AddMembershipHandler : IRequestHandler<AddMembershipCommand>
    {
        private readonly IUnitOfWork uow;

        public AddMembershipHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task Handle(AddMembershipCommand request, CancellationToken cancellationToken)
        {
            await uow.ManagerRepository.AddMembershipAmount(request.MemberId, request.MembershipAmount);
            await uow.SaveAsync();
        }
    }
}

