using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Client.Services.CategoryService
{
    public interface ICategoryService
    {

        event Action OnChange;

        List<Category> Categories { get; set; }
        List<Category> AdminCategories { get; set; }
        Task GetCategories();
        Task GetAdminCategories();
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int categoryId);
        Category CreateNewCategory();
    }
}
