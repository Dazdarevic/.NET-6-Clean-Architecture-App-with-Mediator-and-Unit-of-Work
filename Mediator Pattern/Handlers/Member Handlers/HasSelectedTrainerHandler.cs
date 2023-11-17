using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{
    public class HasSelectedTrainerHandler : IRequestHandler<GetHasSelectedTrainerQuery, bool>
    {
        private readonly IUnitOfWork uow;
        public HasSelectedTrainerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(GetHasSelectedTrainerQuery request, CancellationToken cancellationToken)
        {
            return await uow.MemberRepository.HasSelectedTrainer(request.MemberId);
        }
    }
}
