using System.ComponentModel.DataAnnotations;

namespace Napredne_baze_podataka_API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Type { get; set; }
        public string? Price { get; set; }
        // za sliku
        public string? Url { get; set; }
        public bool IsMain { get; set; }
        public string? PublicId { get; set; }

        public int SellerId { get; set; }
        public Seller? Seller { get; set; }

    }
}
