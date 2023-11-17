using MediatR;
using Napredne_baze_podataka_API.Handlers.Admin;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Commands.Admin
{
    public class AddManagerCommand : IRequest<ManagerS>
    {
        public ManagerS _man { get; set; }

        public AddManagerCommand(ManagerS man)
        {
            _man = man;
        }

    }
}
