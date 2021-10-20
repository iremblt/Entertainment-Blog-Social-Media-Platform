using Entertainment_Blog.DTO.DTOs.PostCategoryDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Abstract
{
    public interface IPostCategoryService
    {
        public Task<List<PostCategoryListDTO>> GetPostCategoryListAsync();
        public Task<PostCategoryListDTO> GetByIdPostCategoryAsync(int id);
        public Task AddPostCategoryAsync(PostCategoryAddDTO postCategoryAdd);
    }
}
