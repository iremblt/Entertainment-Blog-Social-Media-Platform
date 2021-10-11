using Entertainment_Blog.DTO.DTOs.CategoryDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryListDTO>> GetCategoriesAsync();
        Task<CategoryListDTO> GetCategoryByIdAsync(int id);
        Task AddOrEditCategoryAsync(CategoryAddOrEditDTO category);
        Task DeleteCategoryAsync(CategoryDeleteDTO category);
        List<CategoryListDTO> GetCategoriesIncludePosts();
        CategoryListDTO GetCategoryByIdWithPost(int id);
    }
}
