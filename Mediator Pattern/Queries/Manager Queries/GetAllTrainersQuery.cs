using MediatR;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Models;
using Sieve.Models;

namespace Napredne_baze_podataka_API.Queries.Manager_Queries
{
    public class GetAllTrainersQuery : IRequest<IEnumerable<TrainerUser>>
    {
        public SieveModel SieveModel { get; }

        public GetAllTrainersQuery(SieveModel sieveModel)
        {
            SieveModel = sieveModel;
        }
    }
}
