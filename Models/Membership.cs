using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Napredne_baze_podataka_API.Models
{
    public class Membership
    {

        [Key]
        public int IdMembership { get; set; }
        [Required]
        public string? MembershipAmount { get; set; }
        public int? Month { get; set; } // Dodajte atribut za mesec


        [ForeignKey("Member")]
        public int? ID { get; set; }
        //navigatio properties
        public Member? Member { get; set; }
    }
}
