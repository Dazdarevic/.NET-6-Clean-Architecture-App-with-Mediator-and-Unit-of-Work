namespace Napredne_baze_podataka_API.Models
{
    public class Member : User
    {
        public Membership? Membership { get; set; }
        public int? SelectedTrainerId { get; set; }
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>(); // Član može imati više ocena
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();


    }
}
