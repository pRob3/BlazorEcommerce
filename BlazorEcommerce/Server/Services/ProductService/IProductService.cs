using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProducts();

        Task<ServiceResponse<Product>> GetProduct(int productId);

        Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl);
        Task<ServiceResponse<List<Product>>> SearchProduct(string searchText);
        Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText);

        Task<ServiceResponse<List<Product>>> GetFeaturedProducts();
    }
}
