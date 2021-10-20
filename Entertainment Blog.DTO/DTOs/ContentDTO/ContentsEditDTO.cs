using Entertainment_Blog.DTO.DTOs.PostDTO;

namespace Entertainment_Blog.DTO.DTOs.ContentDTO
{
    public class ContentsEditDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public PostListDTO Post { get; set; }
        public int PostId { get; set; }
    }
}
