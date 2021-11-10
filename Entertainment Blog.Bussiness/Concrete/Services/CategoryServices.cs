using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DTO.DTOs.CategoryDTO;
using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Concrete.Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IPostRepository postRepository;
        private readonly IPostCategoryRepository postCatRepository;
        private IMapper mapper;
        public CategoryServices(ICategoryRepository _categoryRepository,IPostRepository _postRepository,IPostCategoryRepository _postCatRepository, IMapper _mapper)
        {
            categoryRepository = _categoryRepository;
            postRepository = _postRepository;
            postCatRepository = _postCatRepository;
            mapper = _mapper;
        }
        public async Task AddCategoryAsync(CategoryAddDTO category)
        {
            var adding = mapper.Map<CategoryAddDTO, Category>(category);
            var list= await GetCategoriesAsync();
            int contains = 0;
            foreach (var item in list)
            {
                if (adding.Name.Contains(item.Name))
                {
                    ++contains;
                }
            }
            if (contains == 0)
            {
                await categoryRepository.AddAsync(adding);
            }
        }        
        public async Task EditCategoryAsync(CategoryEditDTO category)
        {
            var cat=categoryRepository.GetCategoryByIdWithPost(Types.PostCategories,category.Id);
            cat.Name = category.Name;
            var item= PostDeleteFromTheCategory(cat, category.PostIds);
            await categoryRepository.UpdateAsync(item);
        }
        public Category PostDeleteFromTheCategory(Category category, List<int> PostIds)
        {
            if (PostIds !=null)
            {
                foreach (var post in PostIds)
                {
                    category.PostCategories.Remove(category.PostCategories.FirstOrDefault(i => i.PostId == post));
                }
            }
            return category;
        }
        public async Task DeleteCategoryAsync(int id)
        {
            await categoryRepository.DeleteAsync(id);
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

        public CategoryEditDTO GetCategoryByIdWithPost(int id)
        {
            var get = categoryRepository.GetCategoryByIdWithPost(Types.PostCategories, id);
            return mapper.Map<Category, CategoryEditDTO>(get);
        }
    }
}
