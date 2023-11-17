using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Sponsor_Commands
{
    public class AddAdCommand : IRequest<Advertisement>
    {
        public Advertisement Ad { get; }

        public AddAdCommand(Advertisement ad)
        {
            Ad = ad;
        }
    }

}
