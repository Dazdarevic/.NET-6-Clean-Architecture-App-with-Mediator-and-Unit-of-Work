using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Member_Commands;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{

    public class ResetSelectedTrainerHandler : IRequestHandler<ResetSelectedTrainerCommand, bool>
    {
        private readonly IUnitOfWork uow;
        public ResetSelectedTrainerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(ResetSelectedTrainerCommand request, CancellationToken cancellationToken)
        {
            await uow.MemberRepository.ResetSelectedTrainer(request.MemberId);
            return await uow.SaveAsync();
        }
    }
}
