using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DTO.DTOs.PostTagDTO;
using Entertainment_Blog.Entity.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Concrete.Services
{
    public class PostTagServices : IPostTagService
    {
        private readonly IPostTagRepository postTag;
        private readonly IMapper mapper;
        public PostTagServices(IPostTagRepository _postTag, IMapper _mapper)
        {
            postTag = _postTag;
            mapper = _mapper;
        }
        public async Task AddPostTagAsync(PostTagAddDTO postTagAdd)
        {
            var adding = mapper.Map<PostTagAddDTO, PostTag>(postTagAdd);
            await postTag.AddAsync(adding);
        }

        public async Task<PostTagListDTO> GetByIdPostTagAsync(int id)
        {
            var posts = await postTag.GetByIdAsync(id);
            return mapper.Map<PostTagListDTO>(posts);
        }

        public async Task<List<PostTagListDTO>> GetPostTagListAsync()
        {
            var list = await postTag.GetAllAsync();
            return mapper.Map<List<PostTagListDTO>>(list);
        }
    }
}
