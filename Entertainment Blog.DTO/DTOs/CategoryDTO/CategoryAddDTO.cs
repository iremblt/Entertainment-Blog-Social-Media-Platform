using Entertainment_Blog.DTO.DTOs.PostCategoryDTO;
using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.CategoryDTO
{
    public class CategoryAddDTO
    {
        public string Name { get; set; }
        public ICollection<PostCategoryListDTO> PostCategories { get; set; }
    }
}
