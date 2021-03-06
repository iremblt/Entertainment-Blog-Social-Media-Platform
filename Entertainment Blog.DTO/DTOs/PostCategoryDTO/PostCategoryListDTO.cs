using Entertainment_Blog.DTO.DTOs.CategoryDTO;
using Entertainment_Blog.DTO.DTOs.PostDTO;

namespace Entertainment_Blog.DTO.DTOs.PostCategoryDTO
{
    public class PostCategoryListDTO
    {
        public PostListDTO Post { get; set; }
        public int PostId { get; set; }
        public CategoryListDTO Category { get; set; }
        public int CategoryId { get; set; }
    }
}
