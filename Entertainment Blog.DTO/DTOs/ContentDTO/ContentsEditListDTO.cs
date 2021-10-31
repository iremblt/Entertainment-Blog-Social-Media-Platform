using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.ContentDTO
{
    public class ContentsEditListDTO
    {
        public List<ContentsEditDTO> ContentsEdits { get; set; }
        public bool AddMoreContent { get; set; }
    }
}
