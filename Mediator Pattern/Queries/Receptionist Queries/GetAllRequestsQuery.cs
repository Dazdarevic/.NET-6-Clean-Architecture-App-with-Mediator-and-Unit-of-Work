using MediatR;
using Napredne_baze_podataka_API.DTOs;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Receptionist_Queries
{
    public class GetAllRequestsQuery : IRequest<IEnumerable<RegistrationRequestDto>>
    {
    }

}
