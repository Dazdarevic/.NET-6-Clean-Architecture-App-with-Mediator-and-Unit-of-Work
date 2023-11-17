using AutoMapper;
using MediatR;
using Napredne_baze_podataka_API.Controllers;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;
using Napredne_baze_podataka_API.Queries.Admin;

namespace Napredne_baze_podataka_API.Handlers.Admin
{
    public class GetAllAdminsHandler : IRequestHandler<GetAllAdminsQuery, IEnumerable<AdminDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ILogger<AdministratorController> _logger;

        public GetAllAdminsHandler(IUnitOfWork uow, IMapper mapper, ILogger<AdministratorController> logger)
        {
            this.uow = uow;
            this.mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<AdminDto>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("| Log || Testing");
            var admins = await uow.AdministratorRepository.GetAdminsAsync(request.CurrentAdminId);
            var adminsDto = mapper.Map<IEnumerable<AdminDto>>(admins);
            return adminsDto;
        }
    }
}
