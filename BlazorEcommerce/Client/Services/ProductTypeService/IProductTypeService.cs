using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Client.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        event Action OnChange;

        public List<ProductType> ProductTypes { get; set; }

        Task GetProductTypes();
        Task AddProductType(ProductType productType);
        Task UpdateProductType(ProductType productType);
        ProductType CreateNewProductType();
    }
}
