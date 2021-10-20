using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.DTO.DTOs.TagDTO;
using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.PostCreateEditDTOs
{
    public class AddingPostTagDTO
    {
        public PostAddDTO PostAdd { get; set; }
        public List<TagListDTO> SelectedTags { get; set; }
        public List<TagListDTO> TagList { get; set; }
    }
}
