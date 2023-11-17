using MediatR;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Mediator_Pattern.Commands.Seller_Commands;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Handlers.Seller_Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IUnitOfWork uow;

        public AddProductHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            uow.SellerRepository.AddProductAsync(request.Product);
            await uow.SaveAsync();
            var newAdmin = request.Product;
            return newAdmin;
        }
    }
}
