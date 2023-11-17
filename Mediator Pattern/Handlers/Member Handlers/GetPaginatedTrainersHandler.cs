using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{
    public class GetPaginatedTrainersHandler : IRequestHandler<GetPaginatedTrainersQuery, IEnumerable<TrainerUser>>
    {
        private readonly IUnitOfWork uow;

        public GetPaginatedTrainersHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<TrainerUser>> Handle(GetPaginatedTrainersQuery request, CancellationToken cancellationToken)
        {
            var trainers = await uow.MemberRepository.GetPaginatedTrainersAsync(request.Page, request.PageSize);

            return trainers;
        }
    }

}
