using AutoMapper;
using Entertainment_Blog.DTO.DTOs.CategoryDTO;
using Entertainment_Blog.DTO.DTOs.CommentDTO;
using Entertainment_Blog.DTO.DTOs.ContentDTO;
using Entertainment_Blog.DTO.DTOs.PostCategoryDTO;
using Entertainment_Blog.DTO.DTOs.PostDTO;
using Entertainment_Blog.DTO.DTOs.PostTagDTO;
using Entertainment_Blog.DTO.DTOs.TagDTO;
using Entertainment_Blog.DTO.DTOs.UserDTO;
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
            CreateMap<Category,CategoryAddDTO>().ReverseMap();
            CreateMap<Category,CategoryEditDTO>().ReverseMap();
            CreateMap<Category,CategoryDeleteDTO>().ReverseMap();
            CreateMap<Tag,TagListDTO>().ReverseMap();
            CreateMap<Tag,TagAddOrEditDTO>().ReverseMap();
            CreateMap<Tag,TagRemoveDTO>().ReverseMap();
            CreateMap<PostCategory,PostCategoryListDTO>().ReverseMap();
            CreateMap<PostCategory,PostCategoryAddDTO>().ReverseMap();
            CreateMap<PostTag,PostTagListDTO>().ReverseMap();
            CreateMap<PostTag,PostTagAddDTO>().ReverseMap();
            CreateMap<Contents,ContentsListDTO>().ReverseMap();
            CreateMap<Contents,ContentsAddDTO>().ReverseMap();
            CreateMap<Contents,ContentsEditDTO>().ReverseMap();
            CreateMap<Contents,ContentsDeleteDTO>().ReverseMap();
            CreateMap<ApplicationUser,RegisterDTO>().ReverseMap();
            CreateMap<ApplicationUser,SignInDTO>().ReverseMap();
            CreateMap<ApplicationUser,EditUserDTO>().ReverseMap();
            CreateMap<ApplicationUser,UserDetailsDTO>().ReverseMap();
            CreateMap<Comment,CommentListDTO>().ReverseMap();
            CreateMap<Comment,CommentAddDTO>().ReverseMap();
            CreateMap<Comment,CommentDeleteDTO>().ReverseMap();
            CreateMap<Comment,CommentEditDTO>().ReverseMap();
        }
    }
}
