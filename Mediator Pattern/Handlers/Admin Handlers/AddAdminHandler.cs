using MediatR;
using Napredne_baze_podataka_API.Commands.Admin;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Handlers.Admin
{
    public class AddAdminHandler : IRequestHandler<AddAdminCommand, Administrator>
    {
        private readonly IUnitOfWork uow;

        public AddAdminHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<Administrator> Handle(AddAdminCommand request, CancellationToken cancellationToken)
        {
            uow.AdministratorRepository.AddAdmin(request._admin);
            await uow.SaveAsync();
            var newAdmin = request._admin;
            return newAdmin;
        }
    }
}
