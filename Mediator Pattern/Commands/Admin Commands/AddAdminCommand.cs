using MediatR;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Commands.Admin
{
    public class AddAdminCommand : IRequest<Administrator>
    {
        public Administrator _admin { get; set; }

        public AddAdminCommand(Administrator admin)
        {
            _admin = admin;
        }

    }
}
