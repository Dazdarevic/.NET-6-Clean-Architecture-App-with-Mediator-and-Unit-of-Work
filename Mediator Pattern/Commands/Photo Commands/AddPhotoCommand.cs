using MediatR;
using Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Photo_Handlers;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Photo_Commands
{
    public class AddPhotoCommand : IRequest<Photo> // string označava URL fotografije
    {
        public IFormFile? File { get; set; }
    }
}
