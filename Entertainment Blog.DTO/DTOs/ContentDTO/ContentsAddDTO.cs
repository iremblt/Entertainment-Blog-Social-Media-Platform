using Entertainment_Blog.DTO.DTOs.PostDTO;

namespace Entertainment_Blog.DTO.DTOs.ContentDTO
{
    public class ContentsAddDTO
    {
        public string Text { get; set; }
        public string Image { get; set; }
        public PostListDTO Post { get; set; }
        public int PostId { get; set; }
        public bool AddMoreContent { get; set; }
    }
}
