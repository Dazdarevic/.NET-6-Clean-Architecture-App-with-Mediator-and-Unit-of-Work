using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Receptionist_Commands;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Receptionist_Handlers
{
    public class CreateRegistrationRequestHandler : IRequestHandler<CreateRegistrationRequestCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public CreateRegistrationRequestHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(CreateRegistrationRequestCommand request, CancellationToken cancellationToken)
        {
            var isRequestCreated = await _uow.ReceptionistRepository.CreateRegistrationRequestAsync(request.Request);

            if (isRequestCreated)
            {
                await _uow.SaveAsync();
            }

            return isRequestCreated;
        }
    }

}
