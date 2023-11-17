using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Interfaces
{
    public interface ISellerRepository
    {
        void AddProductAsync(Product product);
        Task<IEnumerable<Product>> GetAllProductsAsync();


    }
}
