using MediatR;
using Napredne_baze_podataka_API.Commands.Member_Commands;
using Napredne_baze_podataka_API.Interfaces;

namespace Napredne_baze_podataka_API.Handlers.Member_Handlers
{
    public class ChooseTrainerHandler : IRequestHandler<ChooseTrainerCommand, bool>
    {
        private readonly IUnitOfWork uow;

        public ChooseTrainerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(ChooseTrainerCommand request, CancellationToken cancellationToken)
        {
            await uow.MemberRepository.ChooseTrainer(request.MemberId, request.TrainerId);
            return await uow.SaveAsync();
        }
    }
}
