using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Receptionist_Commands;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Receptionist_Handlers
{
    public class ApproveRegistrationRequestHandler : IRequestHandler<ApproveRegistrationRequestCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public ApproveRegistrationRequestHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(ApproveRegistrationRequestCommand request, CancellationToken cancellationToken)
        {
            var isRequestApproved = await _uow.ReceptionistRepository.ApproveRegistrationRequestAsync(request.RequestId);

            if (isRequestApproved)
            {
                await _uow.SaveAsync();
            }

            return isRequestApproved;
        }
    }

}
