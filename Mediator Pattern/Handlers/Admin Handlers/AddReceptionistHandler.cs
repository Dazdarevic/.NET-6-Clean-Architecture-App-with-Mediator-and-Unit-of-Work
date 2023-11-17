using MediatR;
using Napredne_baze_podataka_API.Commands.Admin;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Handlers.Admin
{
    public class AddReceptionistHandler : IRequestHandler<AddReceptionistCommand, Receptionist>
    {
        private readonly IUnitOfWork uow;

        public AddReceptionistHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<Receptionist> Handle(AddReceptionistCommand request, CancellationToken cancellationToken)
        {
            uow.AdministratorRepository.AddReceptionist(request._rec);
            await uow.SaveAsync();
            var newRec = request._rec;
            return newRec;
        }
    }
}
