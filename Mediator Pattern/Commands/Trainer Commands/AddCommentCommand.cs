using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Trainer_Commands
{
    public class AddCommentCommand : IRequest<bool>
    {
        public Comment Comment { get; }

        public AddCommentCommand(Comment comment)
        {
            Comment = comment;
        }
    }

}
