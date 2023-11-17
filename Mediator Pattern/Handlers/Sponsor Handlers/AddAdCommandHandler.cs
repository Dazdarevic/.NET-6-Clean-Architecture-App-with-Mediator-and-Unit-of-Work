using AutoMapper;
using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Sponsor_Commands;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Sponsor_Handlers
{
    public class AddAdCommandHandler : IRequestHandler<AddAdCommand, Advertisement>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddAdCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<Advertisement> Handle(AddAdCommand request, CancellationToken cancellationToken)
        {
            uow.SponsorRepository.AddAd(request.Ad);
            await uow.SaveAsync();
            var newAdmin = request.Ad;
            return newAdmin;
        }
    }

}
