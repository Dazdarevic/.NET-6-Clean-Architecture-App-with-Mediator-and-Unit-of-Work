using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Queries.Seller_Queries;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Seller_Handlers
{
    public class ListProductsHandler : IRequestHandler<ListProductsQuery, IEnumerable<Product>>
    {
        private readonly IUnitOfWork uow;

        public ListProductsHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<Product>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            return await uow.SellerRepository.GetAllProductsAsync();
        }
    }

}
