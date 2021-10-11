using Entertainment_Blog.DTO.DTOs.PostDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Abstract
{
    public interface IPostService
    {
        Task<List<PostListDTO>> GetPostsAsync();
        List<PostListDTO> GetPostsIncludeCategoriesAndTags();
        List<PostListDTO> GetPostsIncludeCategories();
        List<PostListDTO> GetPostsIncludeTags();
        Task<PostListDTO> GetPostByIdAsync(int id);
        PostListDTO GetPostByIdIncludeCategoriesAndTags(int id);
        PostListDTO GetPostByIdIncludeCategories(int id);
        PostListDTO GetPostByIdIncludeTags(int id);
        Task AddPostAsync(PostAddDTO post);
        Task EditPostAsync(PostEditDTO post);
        Task DeletePostAsync(PostDeleteDTO post);
    }
}
