using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{
    public class GetAverageRatingHandler : IRequestHandler<GetAverageRating, double>
    {
        private readonly IUnitOfWork uow;
        public GetAverageRatingHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<double> Handle(GetAverageRating request, CancellationToken cancellationToken)
        {
            return await uow.MemberRepository.GetAverageRatingByTrainerId(request.TrainerId);
        }
    }

}
