using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Commands.Seller_Commands
{
    public class AddProductCommand : IRequest<Product>
    {
        public Product Product { get; }

        public AddProductCommand(Product product)
        {
            Product = product;
        }
    }

}
