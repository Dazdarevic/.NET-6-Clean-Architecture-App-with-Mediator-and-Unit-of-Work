using AutoMapper;
using MediatR;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Member_Queries;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Member_Handlers
{
    public class GetAllTrainersByMemberHandler : IRequestHandler<GetAllTrainersByMemberQuery, IEnumerable<TrainerDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllTrainersByMemberHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TrainerDto>> Handle(GetAllTrainersByMemberQuery request, CancellationToken cancellationToken)
        {
            var trainers = await uow.MemberRepository.GetAllTrainersAsync();
            var trainersDto = mapper.Map<IEnumerable<TrainerDto>>(trainers);
            return trainersDto;
        }
    }
}
