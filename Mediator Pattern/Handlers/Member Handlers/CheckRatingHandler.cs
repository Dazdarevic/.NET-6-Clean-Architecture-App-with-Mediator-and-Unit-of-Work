using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{
    public class CheckRatingHandler : IRequestHandler<CheckRatingQuery, bool>
    {
        private readonly IUnitOfWork uow;

        public CheckRatingHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(CheckRatingQuery request, CancellationToken cancellationToken)
        {
            return await uow.MemberRepository.CheckRating(request.MemberId, request.TrainerId);
        }
    }
}
