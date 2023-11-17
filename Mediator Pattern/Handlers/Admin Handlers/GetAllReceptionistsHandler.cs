using AutoMapper;
using MediatR;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Queries.Admin;

namespace Napredne_baze_podataka_API.Handlers.Admin
{
    public class GetAllReceptionistsHandler : IRequestHandler<GetAllReceptionistsQuery, IEnumerable<ReceptionistDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllReceptionistsHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ReceptionistDto>> Handle(GetAllReceptionistsQuery request, CancellationToken cancellationToken)
        {
            var receptionists = await uow.AdministratorRepository.GetReceptionistsAsync();
            var receptionistsDto = mapper.Map<IEnumerable<ReceptionistDto>>(receptionists);
            return receptionistsDto;
        }
    }
}
