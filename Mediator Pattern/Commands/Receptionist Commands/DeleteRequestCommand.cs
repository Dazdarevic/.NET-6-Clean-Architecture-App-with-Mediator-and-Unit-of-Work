using MediatR;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Receptionist_Commands
{
    public class DeleteRequestCommand : IRequest<bool>
    {
        public int RequestId { get; }

        public DeleteRequestCommand(int requestId)
        {
            RequestId = requestId;
        }
    }

}
