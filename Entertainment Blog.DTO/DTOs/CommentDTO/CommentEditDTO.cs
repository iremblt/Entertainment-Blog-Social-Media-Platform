using Entertainment_Blog.DTO.DTOs.PostDTO;
using System;

namespace Entertainment_Blog.DTO.DTOs.CommentDTO
{
    public class CommentEditDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public PostListDTO Post { get; set; }
        public int PostId { get; set; }
        public UserDTO.UserDetailsDTO User { get; set; }
        public string UserId { get; set; }
    }
}
