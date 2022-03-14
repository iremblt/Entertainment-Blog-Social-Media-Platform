using Entertainment_Blog.DTO.DTOs.PostCreateEditDTOs;
using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.DTO.DTOs.SearchDTO;
using Entertainment_Blog.Entity.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Abstract
{
    public interface IPostService
    {
        Task<List<PostListDTO>> GetPostsAsync();
        Task<List<PostListDTO>> GetPostsOrderByDateTime();
        List<PostListDTO> GetPostsIncludeCategoriesAndTags();
        List<PostListDTO> GetPostsIncludeCategories();
        List<PostListDTO> GetPostsIncludeTags();
        Task<PostListDTO> GetPostByIdAsync(int id);
        PostListDTO GetPostByIdIncludeCategories(int id);
        PostListDTO GetPostByIdIncludeTags(int id);
        PostEditDTO GetEditPostByIdIncludeCategoriesAndTags(int id);
        Task<Post> AddPostAsync(PostAddDTO post);
        Task<Post> EditPostAsync(PostEditDTO post);
        Task DeletePostAsync(PostDeleteDTO post);
        Task<PostNextAndLastDTO> GetNextAndLastPostOfThePostAsync(int id);
        IQueryable<PostListDTO> SearchPost(SearchDTO search);
        Task<EdittingPostTagsCategoryDTO> MappingToEdittingPostTagsCategoryDTO(PostEditDTO postEdits);
        Task<List<PostListDTO>> GetPostByCategoryIdAsync(int id);
        PostListDTO GetPostByIdWithEvertyhing(int id);
    }
}
