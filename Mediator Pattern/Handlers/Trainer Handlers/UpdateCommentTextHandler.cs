using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Trainer_Commands;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Trainer_Handlers
{

    public class UpdateCommentTextHandler : IRequestHandler<UpdateCommentTextCommand, bool>
    {
        private readonly IUnitOfWork uow;

        public UpdateCommentTextHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(UpdateCommentTextCommand request, CancellationToken cancellationToken)
        {
            var isUpdated = await uow.TrainerRepository.UpdateCommentTextAsync(request.CommentId, request.CommentText);
            return isUpdated;
        }
    }

}
