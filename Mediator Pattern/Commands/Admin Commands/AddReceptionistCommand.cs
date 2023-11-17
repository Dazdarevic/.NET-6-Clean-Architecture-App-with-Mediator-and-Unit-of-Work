using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Commands.Admin
{
    public class AddReceptionistCommand : IRequest<Receptionist>
    {
        public Receptionist _rec { get; set; }

        public AddReceptionistCommand(Receptionist rec)
        {
            _rec = rec;
        }

    }
}
