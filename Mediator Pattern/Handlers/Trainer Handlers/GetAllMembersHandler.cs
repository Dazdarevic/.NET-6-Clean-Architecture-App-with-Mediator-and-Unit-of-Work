using AutoMapper;
using MediatR;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Trainer;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Trainer_Handlers
{
    public class GetAllMembersHandler : IRequestHandler<GetAllMembersQuery, IEnumerable<Member>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllMembersHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Member>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await uow.TrainerRepository.GetAllMembersAsync();
            return members;
        }
    }

}
