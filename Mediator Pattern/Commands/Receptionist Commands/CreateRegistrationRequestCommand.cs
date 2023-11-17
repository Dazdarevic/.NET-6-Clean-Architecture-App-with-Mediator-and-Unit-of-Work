using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Receptionist_Commands
{
    public class CreateRegistrationRequestCommand : IRequest<bool>
    {
        public RegistrationRequest Request { get; }

        public CreateRegistrationRequestCommand(RegistrationRequest request)
        {
            Request = request;
        }
    }

}
