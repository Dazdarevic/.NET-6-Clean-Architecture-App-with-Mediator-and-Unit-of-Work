namespace Napredne_baze_podataka_API.Models
{
    public class Seller : User
    {
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
