using AutoMapper;
using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Sponsor_Queries;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Sponsor_Handlers
{
    public class ListAdsHandler : IRequestHandler<ListAdsQuery, IEnumerable<Advertisement>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ListAdsHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Advertisement>> Handle(ListAdsQuery request, CancellationToken cancellationToken)
        {
            var ads = await uow.SponsorRepository.GetAllAdsAsync();
            return ads;
        }
    }

}
