using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{
    public class GetTrainerHandler : IRequestHandler<GetTrainerQuery, TrainerUser>
    {
        private readonly IUnitOfWork uow;

        public GetTrainerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<TrainerUser> Handle(GetTrainerQuery request, CancellationToken cancellationToken)
        {
            return (TrainerUser)await uow.MemberRepository.GetTrainer(request.TrainerId);
        }
    }
}
