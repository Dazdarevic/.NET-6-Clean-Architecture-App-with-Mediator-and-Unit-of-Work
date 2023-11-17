using System.ComponentModel.DataAnnotations;

namespace Napredne_baze_podataka_API.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Value { get; set; } // Ocena (npr. od 1 do 5)

        public int TrainerId { get; set; }
        public TrainerUser? Trainer { get; set; } // Navigation property

        public int MemberId { get; set; } 
        public Member? Member { get; set; } // Navigation property
    }

}
