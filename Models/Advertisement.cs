using System.ComponentModel.DataAnnotations;

namespace Napredne_baze_podataka_API.Models
{
    public class Advertisement
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public bool IsMain { get; set; }
        public string? PublicId { get; set; }
        public int SponsorId { get; set; }
        public Sponsor? Sponsor { get; set; }

    }
}
