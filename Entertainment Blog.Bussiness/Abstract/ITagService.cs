using Entertainment_Blog.DTO.DTOs.SearchDTO;
using Entertainment_Blog.DTO.DTOs.TagDTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Abstract
{
    public interface ITagService
    {
        Task<List<TagListDTO>> GetTagsAsync();
        List<TagListDTO> GetTagsIncludePosts();
        Task<TagListDTO> GetTagsByIdAsync(int id);
        TagListDTO GetTagsByIdIncludePosts(int id);
        Task AddOrEditTagAsync(TagAddOrEditDTO tag);
        Task RemoveTagAsync(TagRemoveDTO tag);
        IQueryable<TagListDTO> SearchTag(SearchDTO search);
    }
}
