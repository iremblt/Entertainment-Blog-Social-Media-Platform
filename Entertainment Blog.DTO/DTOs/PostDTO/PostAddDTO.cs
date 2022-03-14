using Entertainment_Blog.DTO.DTOs.ContentDTO;
using Entertainment_Blog.DTO.DTOs.PostCategoryDTO;
using Entertainment_Blog.DTO.DTOs.PostTagDTO;
using Entertainment_Blog.Entity.Concrete;
using System;
using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.PostDTO
{
    //Application User'ı direk kullanmamna lazım !!!
    public class PostAddDTO
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public List<ContentsListDTO> Contents { get; set; }
        public string Thumbnail { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public bool IsPublished { get; set; } = false;
        public ICollection<PostCategoryListDTO> PostCategories { get; set; }
        public ICollection<PostTagListDTO> PostTags { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> TagIds { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
