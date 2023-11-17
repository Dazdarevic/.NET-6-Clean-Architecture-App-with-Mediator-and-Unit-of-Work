using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Trainer_Commands;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Trainer_Handlers
{
    public class AddCommentHandler : IRequestHandler<AddCommentCommand, bool>
    {
        private readonly IUnitOfWork uow;

        public AddCommentHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var isAdded = await uow.TrainerRepository.AddCommentAsync(request.Comment);
            if (isAdded)
            {
                await uow.SaveAsync();
            }
            return isAdded;
        }
    }

}
