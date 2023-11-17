using MediatR;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Member_Commands
{
    public class ExtendMembershipCommand : IRequest<bool>
    {
        public int MemberId { get; set; }
        public string MembershipAmount { get; set; }
        public int Month { get; set; }
    }
}
