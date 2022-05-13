using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Server.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        Task<ServiceResponse<List<ProductType>>> GetProductTypes();
        Task<ServiceResponse<List<ProductType>>> AddProductType(ProductType productType);
        Task<ServiceResponse<List<ProductType>>> UpdateProductType(ProductType productType);


    }
}
