using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DTO.DTOs.CategoryDTO;
using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Concrete.Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private IMapper mapper;
        public CategoryServices(ICategoryRepository _categoryRepository,IMapper _mapper)
        {
            categoryRepository = _categoryRepository;
            mapper = _mapper;
        }
        public async Task AddOrEditCategoryAsync(CategoryAddOrEditDTO category)
        {
            var adding = mapper.Map<CategoryAddOrEditDTO, Category>(category);
            if (category.Id != 0)
            {
                await categoryRepository.UpdateAsync(adding);
            }
            await categoryRepository.AddAsync(adding);
        }

        public async Task DeleteCategoryAsync(CategoryDeleteDTO category)
        {
            var delete = mapper.Map<CategoryDeleteDTO, Category>(category);
            await categoryRepository.DeleteAsync(delete.Id);
        }

        public async Task<List<CategoryListDTO>> GetCategoriesAsync()
        {
            var lists = await categoryRepository.GetAllAsync();
            return mapper.Map<List<CategoryListDTO>>(lists);
        }

        public List<CategoryListDTO> GetCategoriesIncludePosts()
        {
            var list = categoryRepository.GetCategoriesIncludePosts(Types.PostCategories);
            return mapper.Map<List<CategoryListDTO>>(list);
        }

        public async Task<CategoryListDTO> GetCategoryByIdAsync(int id)
        {
            var result = await categoryRepository.GetByIdAsync(id);
            if (result == null) { return null; }
            return mapper.Map<Category, CategoryListDTO>(result);
        }

        public CategoryListDTO GetCategoryByIdWithPost(int id)
        {
            var get = categoryRepository.GetCategoryByIdWithPost(Types.PostCategories, id);
            return mapper.Map<Category, CategoryListDTO>(get);
        }
    }
}
