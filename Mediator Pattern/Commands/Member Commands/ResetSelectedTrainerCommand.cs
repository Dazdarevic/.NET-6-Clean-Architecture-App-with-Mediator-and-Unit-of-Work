using MediatR;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Member_Commands
{
    public class ResetSelectedTrainerCommand : IRequest<bool>
    {
        public int MemberId { get; }

        public ResetSelectedTrainerCommand(int memberId)
        {
            MemberId = memberId;
        }
    }
}
