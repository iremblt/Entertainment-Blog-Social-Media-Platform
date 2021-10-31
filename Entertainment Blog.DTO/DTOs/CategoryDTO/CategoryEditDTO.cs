using Entertainment_Blog.DTO.DTOs.PostCategoryDTO;
using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.CategoryDTO
{
    public class CategoryEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PostCategoryListDTO> PostCategories { get; set; }
        public List<int> PostIds { get; set; }
    }
}
