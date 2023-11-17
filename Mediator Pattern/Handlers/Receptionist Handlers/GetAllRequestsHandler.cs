using AutoMapper;
using MediatR;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Receptionist_Queries;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Receptionist_Handlers
{

    public class GetAllRequestsHandler : IRequestHandler<GetAllRequestsQuery, IEnumerable<RegistrationRequestDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllRequestsHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegistrationRequestDto>> Handle(GetAllRequestsQuery request, CancellationToken cancellationToken)
        {
            var allRequests = await _uow.ReceptionistRepository.GetAllRequestsAsync();
            var allRequestsDto = _mapper.Map<IEnumerable<RegistrationRequestDto>>(allRequests);
            return allRequestsDto;
        }
    }

}
