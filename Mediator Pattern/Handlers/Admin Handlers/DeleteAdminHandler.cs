using MediatR;
using Napredne_baze_podataka_API.Commands.Admin;
using Napredne_baze_podataka_API.Interfaces;

namespace Napredne_baze_podataka_API.Handlers.Admin
{
    public class DeleteAdminHandler : IRequestHandler<DeleteAdminCommand>
    {
        private readonly IUnitOfWork uow;

        public DeleteAdminHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            uow.AdministratorRepository.DeleteAdmin(request.AdminId);
            await uow.SaveAsync();
        }
    }
}
