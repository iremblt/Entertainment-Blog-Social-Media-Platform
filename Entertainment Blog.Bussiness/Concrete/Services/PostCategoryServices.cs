using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DTO.DTOs.PostCategoryDTO;
using Entertainment_Blog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Concrete.Services
{
    public class PostCategoryServices:IPostCategoryService
    {
        private readonly IPostCategoryRepository postCategory;
        private readonly IMapper mapper;
        public PostCategoryServices(IPostCategoryRepository _postCategory,IMapper _mapper)
        {
            postCategory = _postCategory;
            mapper = _mapper;
        }
        public async Task<List<PostCategoryListDTO>> GetPostCategoryListAsync()
        {
            var list= await postCategory.GetAllAsync();
            return mapper.Map<List<PostCategoryListDTO>>(list);
        }
        public async Task<PostCategoryListDTO> GetByIdPostCategoryAsync(int id)
        {
            var posts = await postCategory.GetByIdAsync(id);
            return mapper.Map<PostCategoryListDTO>(posts);
        }
        public async Task AddPostCategoryAsync(PostCategoryAddDTO postCategoryAdd)
        {
            var adding = mapper.Map<PostCategoryAddDTO,PostCategory>(postCategoryAdd);
            await postCategory.AddAsync(adding);
        }
    }
}
