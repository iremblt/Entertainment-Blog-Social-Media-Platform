using System.Collections.Generic;

namespace Entertainment_Blog.DTO.DTOs.CategoryDTO
{
    public class CategoryViewListsDTO
    {
        public string DeletedName { get; set; }
        public string AddedName { get; set; }
        public int Id { get; set; }
        public  List<CategoryListDTO> CategoryLists{ get; set; }
        public CategoryAddDTO CategoryAdd { get; set; }
    }
}
