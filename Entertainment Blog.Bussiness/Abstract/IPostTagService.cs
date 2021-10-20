using Entertainment_Blog.DTO.DTOs.PostTagDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Abstract
{
    public interface IPostTagService
    {
        public Task<List<PostTagListDTO>> GetPostTagListAsync();
        public Task<PostTagListDTO> GetByIdPostTagAsync(int id);
        public Task AddPostTagAsync(PostTagAddDTO postTagAdd);
    }
}
