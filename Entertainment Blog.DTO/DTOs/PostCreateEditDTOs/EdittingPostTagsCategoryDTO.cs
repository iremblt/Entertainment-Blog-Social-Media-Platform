using Entertainment_Blog.DTO.DTOs.CategoryDTO;
using Entertainment_Blog.DTO.DTOs.PostCategoryDTO;
using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.DTO.DTOs.PostTagDTO;
using Entertainment_Blog.DTO.DTOs.TagDTO;
using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.PostCreateEditDTOs
{
    public class EdittingPostTagsCategoryDTO
    {
        public PostEditDTO PostEdit { get; set; }
        public ICollection<PostCategoryListDTO> SelectedCategories { get; set; }
        public List<CategoryListDTO> CategoryList { get; set; }
        public ICollection<PostTagListDTO> SelectedTags { get; set; }
        public List<TagListDTO> TagList { get; set; }
    }
}
