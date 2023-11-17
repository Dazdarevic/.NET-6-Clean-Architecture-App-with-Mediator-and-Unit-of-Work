using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Mediator_Pattern.Queries.Sponsor_Queries
{
    public class ListAdsQuery : IRequest<IEnumerable<Advertisement>>
    {
    }
}
