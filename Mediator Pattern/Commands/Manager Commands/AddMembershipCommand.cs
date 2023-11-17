using MediatR;

namespace Napredne_baze_podataka_API.Commands.Manager_Commands
{
    public class AddMembershipCommand : IRequest
    {
        public int MemberId { get; }
        public string MembershipAmount { get; }

        public AddMembershipCommand(int memberId, string membershipAmount)
        {
            MemberId = memberId;
            MembershipAmount = membershipAmount;
        }
    }
}
