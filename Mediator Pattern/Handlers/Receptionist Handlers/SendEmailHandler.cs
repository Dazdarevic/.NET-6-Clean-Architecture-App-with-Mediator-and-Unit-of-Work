using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Receptionist_Commands;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Receptionist_Handlers
{

    public class SendEmailHandler : IRequestHandler<SendEmailCommand>
    {
        private readonly IUnitOfWork _uow;

        public SendEmailHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            await _uow.EmailSenderRepository.SendEmailAsync(request.EmailModel.Email, 
                request.EmailModel.Subject, request.EmailModel.Message);
        }
    }

}
