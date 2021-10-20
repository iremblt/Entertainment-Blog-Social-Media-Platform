using Entertainment_Blog.DTO.DTOs.CategoryDTO;
using Entertainment_Blog.DTO.DTOs.ContentDTO;
using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.DTO.DTOs.TagDTO;
using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.PostCreateEditDTOs
{
    public class AddingPostTagsCategoryDTO
    {
        public PostAddDTO PostAdd { get; set; }
        public List<CategoryListDTO> SelectedCategories { get; set; }
        public List<CategoryListDTO> CategoryList { get; set; }        
        public List<TagListDTO> SelectedTags { get; set; }
        public List<TagListDTO> TagList { get; set; }
        public TagAddOrEditDTO Tag { get; set; }
        public ContentsAddDTO Contents { get; set; }
    }
}
