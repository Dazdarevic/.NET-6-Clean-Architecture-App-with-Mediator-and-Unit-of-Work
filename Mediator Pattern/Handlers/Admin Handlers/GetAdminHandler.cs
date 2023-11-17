using AutoMapper;
using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;
using Napredne_baze_podataka_API.Queries.Admin;

namespace Napredne_baze_podataka_API.Handlers.Admin
{
    public class GetAdminHandler : IRequestHandler<GetAdminQuery, Administrator>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAdminHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }


        public async Task<Administrator> Handle(GetAdminQuery request, CancellationToken cancellationToken)
        {
            return (Administrator)await uow.AdministratorRepository.GetAdmin(request.CurrentAdminId);
        }
    }
}
