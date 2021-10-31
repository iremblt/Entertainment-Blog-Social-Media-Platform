using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.TagDTO
{
    public class TagViewListDTO
    {
        public string DeletedName { get; set; }
        public string AddedName { get; set; }
        public int Id { get; set; }
        public List<TagListDTO> TagLists { get; set; }
        public TagAddOrEditDTO TagAdd { get; set; }
        public SearchDTO.SearchDTO Search { get; set; }
    }
}
