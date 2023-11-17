using MediatR;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Queries.Admin
{
    public class GetAdminQuery : IRequest<Administrator>
    {
        public int CurrentAdminId { get; set; }
        public GetAdminQuery(int currentAdminId)
        {
            CurrentAdminId = currentAdminId;
        }
    }
}
