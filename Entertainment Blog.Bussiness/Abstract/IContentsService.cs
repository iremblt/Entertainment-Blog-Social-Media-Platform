using Entertainment_Blog.DTO.DTOs.ContentDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Abstract
{
    public interface IContentsService
    {
        public Task AddContentsAsync(ContentsAddDTO contents);
        public Task<ContentsListDTO> GetByContentsIdAsync(int id);
        public Task<List<ContentsListDTO>> GetContentsListAsync();
        public Task EditContentsAsync(ContentsEditDTO contents);
        public Task RemoveContentsAsync(ContentsDeleteDTO contents);
        public Task<List<ContentsListDTO>> GetContentsIncludePost();
        public Task<List<ContentsEditDTO>> GetContentsByPostIdAsync(int postid);
    }
}
