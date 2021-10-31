using Entertainment_Blog.DTO.DTOs.CategoryDTO;
using Entertainment_Blog.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryListDTO>> GetCategoriesAsync();
        Task<CategoryListDTO> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryAddDTO category);
        Task EditCategoryAsync(CategoryEditDTO category);
        Task DeleteCategoryAsync(int id);
        List<CategoryListDTO> GetCategoriesIncludePosts();
        CategoryEditDTO GetCategoryByIdWithPost(int id);
        Task<Category> PostDeleteFromTheCategoryAsync(Category category, List<int> PostIds);
    }
}
