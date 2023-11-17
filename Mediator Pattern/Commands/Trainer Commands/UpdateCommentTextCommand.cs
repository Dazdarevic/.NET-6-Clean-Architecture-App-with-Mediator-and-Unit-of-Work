using MediatR;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Trainer_Commands
{
    public class UpdateCommentTextCommand : IRequest<bool>
    {
        public int CommentId { get; }
        public string CommentText { get; }

        public UpdateCommentTextCommand(int commentId, string commentText)
        {
            CommentId = commentId;
            CommentText = commentText;
        }
    }

}
