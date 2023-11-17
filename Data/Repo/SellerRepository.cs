using Microsoft.EntityFrameworkCore;
using Napredne_baze_podataka_API.Interfaces;
using Napredne_baze_podataka_API.Models;

namespace Napredne_baze_podataka_API.Data.Repo
{
    public class SellerRepository : ISellerRepository
    {
        private readonly DataContext dc;

        public SellerRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public void AddProductAsync(Product product)
        {
            dc.Products.Add(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await dc.Products.ToListAsync();
        }
    }
}
