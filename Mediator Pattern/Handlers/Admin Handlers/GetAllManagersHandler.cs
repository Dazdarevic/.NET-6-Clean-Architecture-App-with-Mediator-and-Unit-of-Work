using AutoMapper;
using MediatR;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Queries.Admin;

namespace Napredne_baze_podataka_API.Handlers.Admin
{
    public class GetAllManagersHandler : IRequestHandler<GetAllManagersQuery, IEnumerable<ManagerDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllManagersHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ManagerDto>> Handle(GetAllManagersQuery request, CancellationToken cancellationToken)
        {
            var managers = await uow.AdministratorRepository.GetManagersAsync();
            var managersDto = mapper.Map<IEnumerable<ManagerDto>>(managers);
            return managersDto;
        }
    }
}
