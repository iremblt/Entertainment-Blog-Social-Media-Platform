using Entertainment_Blog.DTO.DTOs.CategoryDTO;
using Entertainment_Blog.DTO.DTOs.PostDTO;
using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.PostCreateEditDTOs
{
    public class AddingPostCategoryDTO
    {
        public PostAddDTO PostAdd { get; set; }
        public List<CategoryListDTO> SelectedCategories { get; set; }
        public List<CategoryListDTO> CategoryList { get; set; }
    }
}
