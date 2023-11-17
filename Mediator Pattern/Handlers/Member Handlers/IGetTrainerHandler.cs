using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{
    public interface IGetTrainerHandler
    {
        Task<TrainerUser> Handle(GetTrainerQuery request, CancellationToken cancellationToken);
    }
}