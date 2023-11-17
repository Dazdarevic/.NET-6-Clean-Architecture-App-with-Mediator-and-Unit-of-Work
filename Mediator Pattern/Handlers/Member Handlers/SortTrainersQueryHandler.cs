using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{
    public class SortTrainersQueryHandler : IRequestHandler<SortTrainersQuery, IEnumerable<TrainerUser>>
    {
        private readonly IUnitOfWork uow;
        public SortTrainersQueryHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        public async Task<IEnumerable<TrainerUser>> Handle(SortTrainersQuery request, CancellationToken cancellationToken)
        {
            if (request.SortByField != null && (request.SortByField == "firstName" || request.SortByField == "lastName"))
            {
                return await uow.MemberRepository.SortTrainersAsync(request.SortByField);
            }
            return null;
        }
    }

}
