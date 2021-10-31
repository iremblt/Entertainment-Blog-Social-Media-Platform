using Entertainment_Blog.DTO.DTOs.ContentDTO;
using Entertainment_Blog.DTO.DTOs.PostCategoryDTO;
using Entertainment_Blog.DTO.DTOs.PostTagDTO;
using System;
using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.PostDTO
{
    public class PostEditDTO
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
        public List<int> CategoryIds { get; set; }
        public List<int> TagIds { get; set; }
    }
}
