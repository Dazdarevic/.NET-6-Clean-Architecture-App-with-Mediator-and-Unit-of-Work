using MediatR;
using Napredne_baze_podataka_API.DTOs;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Receptionist_Commands
{
    public class SendEmailCommand : IRequest
    {
        public EmailDto EmailModel { get; }

        public SendEmailCommand(EmailDto emailModel)
        {
            EmailModel = emailModel;
        }
    }

}
