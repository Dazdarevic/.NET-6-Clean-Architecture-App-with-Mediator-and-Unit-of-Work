using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Seller_Queries
{
    public class ListProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
