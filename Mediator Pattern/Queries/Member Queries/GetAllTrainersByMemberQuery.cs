using MediatR;
using Napredne_baze_podataka_API.DTOs;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries
{
    public class GetAllTrainersByMemberQuery : IRequest<IEnumerable<TrainerDto>>
    {
    }
}
