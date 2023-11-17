using MediatR;
using Napredne_baze_podataka_API.DTOs;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Queries.Admin
{
    public class GetAllAdminsQuery : IRequest<IEnumerable<AdminDto>>
    {
        public int CurrentAdminId { get; set; }
        public GetAllAdminsQuery(int currentAdminId)
        {
            CurrentAdminId = currentAdminId;
        }
    }
}
