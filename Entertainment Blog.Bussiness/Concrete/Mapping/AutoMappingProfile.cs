using AutoMapper;
using Entertainment_Blog.DTO.DTOs.CategoryDTO;
using Entertainment_Blog.DTO.DTOs.PostCategoryDTO;
using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.DTO.DTOs.PostTagDTO;
using Entertainment_Blog.DTO.DTOs.TagDTO;
using Entertainment_Blog.Entity.Concrete;

namespace Entertainment_Blog.Bussiness.Concrete.Mapping
{
    public class AutoMappingProfile:Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Post,PostListDTO>().ReverseMap();
            CreateMap<Post,PostAddDTO>().ReverseMap();
            CreateMap<Post,PostDeleteDTO>().ReverseMap();
            CreateMap<Post,PostEditDTO>().ReverseMap();
            CreateMap<Category,CategoryListDTO>().ReverseMap();
            CreateMap<Category,CategoryAddOrEditDTO>().ReverseMap();
            CreateMap<Category,CategoryDeleteDTO>().ReverseMap();
            CreateMap<Tag,TagListDTO>().ReverseMap();
            CreateMap<Tag,TagAddOrEditDTO>().ReverseMap();
            CreateMap<Tag,TagRemoveDTO>().ReverseMap();
            CreateMap<PostCategory,PostCategoryListDTO>().ReverseMap();
            CreateMap<PostTag,PostTagListDTO>().ReverseMap();
        }
    }
}
