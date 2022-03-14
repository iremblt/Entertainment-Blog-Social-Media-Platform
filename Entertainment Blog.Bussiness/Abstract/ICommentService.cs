using Entertainment_Blog.DTO.DTOs.CommentDTO;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Abstract
{
    public interface ICommentService
    {
        public Task AddComment(CommentAddDTO comment);
    }
}
