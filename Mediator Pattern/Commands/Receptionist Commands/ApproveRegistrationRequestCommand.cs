using MediatR;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Receptionist_Commands
{
    public class ApproveRegistrationRequestCommand : IRequest<bool>
    {
        public int RequestId { get; }

        public ApproveRegistrationRequestCommand(int requestId)
        {
            RequestId = requestId;
        }
    }

}
