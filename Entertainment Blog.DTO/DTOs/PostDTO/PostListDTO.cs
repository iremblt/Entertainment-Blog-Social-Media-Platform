using Entertainment_Blog.DTO.DTOs.CommentDTO;
using Entertainment_Blog.DTO.DTOs.ContentDTO;
using Entertainment_Blog.DTO.DTOs.PostCategoryDTO;
using Entertainment_Blog.DTO.DTOs.PostTagDTO;
using Entertainment_Blog.DTO.DTOs.UserDTO;
using System;
using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.PostDTO
{
    public class PostListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public List<ContentsListDTO> Contents { get; set; }
        public string Thumbnail { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsPublished { get; set; }
        public ICollection<PostCategoryListDTO> PostCategories { get; set; }
        public ICollection<PostTagListDTO> PostTags { get; set; }
        public EditUserDTO User { get; set; }
        public string UserId { get; set; }
        public List<CommentListDTO> Comments { get; set; }
        public CommentAddDTO AddComments { get; set; }


    }
}
