using MediatR;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Trainer
{
    public class GetAllMembersQuery : IRequest<IEnumerable<Member>>
    {
    }
}
