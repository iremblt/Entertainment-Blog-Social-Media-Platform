using Entertainment_Blog.DTO.DTOs.CommentDTO;

namespace Entertainment_Blog.DTO.DTOs.PostDTO
{
    public class PostNextAndLastDTO
    {
        public PostListDTO Post { get; set; }
        public PostListDTO PostNext { get; set; }
        public PostListDTO PostLast { get; set; }
        public CommentAddDTO CommentAdd { get; set; }
    }
}
