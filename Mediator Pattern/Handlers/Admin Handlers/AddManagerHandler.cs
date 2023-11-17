using MediatR;
using Napredne_baze_podataka_API.Commands.Admin;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Handlers.Admin
{
    public class AddManagerHandler : IRequestHandler<AddManagerCommand, ManagerS>
    {
        private readonly IUnitOfWork uow;

        public AddManagerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public async Task<ManagerS> Handle(AddManagerCommand request, CancellationToken cancellationToken)
        {
            uow.AdministratorRepository.AddManager(request._man);
            await uow.SaveAsync();
            var newAdmin = request._man;
            return newAdmin;
        }
    }
}
