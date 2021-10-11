using Entertainment_Blog.DTO.DTOs.PostTagDTO;
using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.TagDTO
{
    public class TagAddOrEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PostTagListDTO> PostTags { get; set; }
    }
}
