using MediatR;

namespace Napredne_baze_podataka_API.Commands.Admin
{
    public class DeleteAdminCommand : IRequest
    {
        public int AdminId { get; set; }

        public DeleteAdminCommand(int adminId)
        {
            AdminId = adminId;
        }
    }
}
