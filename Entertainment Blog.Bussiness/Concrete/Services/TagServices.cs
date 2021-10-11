using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DTO.DTOs.TagDTO;
using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment_Blog.Bussiness.Concrete.Services
{
    public class TagServices : ITagService
    {
        private readonly ITagRepository tagRepository;
        private IMapper mapper;
        public TagServices(ITagRepository _tagRepository,IMapper _mapper)
        {
            tagRepository = _tagRepository;
            mapper = _mapper;
        }
        public async Task AddOrEditTagAsync(TagAddOrEditDTO tag)
        {
            var adding = mapper.Map<TagAddOrEditDTO,Tag>(tag);
            if (adding.Id != 0)
            {
                await tagRepository.UpdateAsync(adding);
            }
            await tagRepository.AddAsync(adding);
        }

        public async Task<List<TagListDTO>> GetTagsAsync()
        {
            var list = await tagRepository.GetAllAsync();
            return mapper.Map<List<TagListDTO>>(list);
        }

        public async Task<TagListDTO> GetTagsByIdAsync(int id)
        {
            var result = await tagRepository.GetByIdAsync(id);
            if (result == null) { return null; }
            var mapping = mapper.Map<Tag,TagListDTO>(result);
            return mapping;
        }

        public TagListDTO GetTagsByIdIncludePosts(int id)
        {
            var gets = tagRepository.GetTagsByIdWithPost(Types.PostTags, id);
            return mapper.Map<Tag, TagListDTO>(gets);
        }

        public List<TagListDTO> GetTagsIncludePosts()
        {
            var lists = tagRepository.GetTagsIncludePosts(Types.PostTags);
            return mapper.Map<List<TagListDTO>>(lists);
        }

        public async Task RemoveTagAsync(TagRemoveDTO tag)
        {
            var removed = mapper.Map<TagRemoveDTO,Tag>(tag);
            await tagRepository.DeleteAsync(removed.Id);
        }
    }
}
