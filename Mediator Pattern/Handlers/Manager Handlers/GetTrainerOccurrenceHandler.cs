using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Queries.Manager_Queries;

namespace Napredne_baze_podataka_API.Handlers.Trainers
{
    public class GetTrainerOccurrenceHandler : IRequestHandler<GetTrainerOccurrenceQuery, int>
    {
        private readonly IUnitOfWork uow;

        public GetTrainerOccurrenceHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<int> Handle(GetTrainerOccurrenceQuery request, CancellationToken cancellationToken)
        {
            return await uow.ManagerRepository.GetTrainerIdOccurrenceAsync(request.TrainerId);
        }
    }
}
