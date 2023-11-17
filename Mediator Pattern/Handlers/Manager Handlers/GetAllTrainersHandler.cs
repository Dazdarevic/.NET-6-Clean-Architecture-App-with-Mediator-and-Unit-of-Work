using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Sieve.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Queries.Manager_Queries;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Handlers.Trainers
{
    public class GetAllTrainersHandler : IRequestHandler<GetAllTrainersQuery, IEnumerable<TrainerUser>>
    {
        private readonly IUnitOfWork uow;
        private readonly ISieveProcessor _sieveProcessor;

        public GetAllTrainersHandler(IUnitOfWork uow, ISieveProcessor sieveProcessor)
        {
            this.uow = uow;
            _sieveProcessor = sieveProcessor;
        }

        public async Task<IEnumerable<TrainerUser>> Handle(GetAllTrainersQuery request, CancellationToken cancellationToken)
        {
            var trainers = await uow.ManagerRepository.GetAllTrainersAsync();

            var filteredTrainers = _sieveProcessor.Apply<TrainerUser>(request.SieveModel, trainers.AsQueryable());

            return filteredTrainers;
        }
    }
}
