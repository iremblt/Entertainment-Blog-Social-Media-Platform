using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.DTO.DTOs.UserDTO;
using System;

namespace Entertainment_Blog.DTO.DTOs.CommentDTO
{
    public class CommentDeleteDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public PostListDTO Post { get; set; }
        public int PostId { get; set; }
        public UserDetailsDTO User { get; set; }
        public string UserId { get; set; }
    }
}
