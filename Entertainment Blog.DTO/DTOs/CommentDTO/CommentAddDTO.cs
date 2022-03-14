using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.DTO.DTOs.UserDTO;
using Entertainment_Blog.Entity.Concrete;
using System;

namespace Entertainment_Blog.DTO.DTOs.CommentDTO
{
    public class CommentAddDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public PostListDTO Post { get; set; }
        public int PostId { get; set; }
        //public EditUserDTO User { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
