using AutoMapper;
using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DTO.DTOs.SearchDTO;
using Entertainment_Blog.DTO.DTOs.TagDTO;
using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using System.Collections.Generic;
using System.Linq;
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
            if (tag.Id != 0)
            {
                var getTag = tagRepository.GetTagsByIdWithPost(Types.PostTags,tag.Id); 
                getTag.Name = tag.Name;
                var item = PostDeleteFromTheTag(getTag, tag.PostIds);
                await tagRepository.UpdateAsync(item);
            }
            else
            {
                var adding = mapper.Map<TagAddOrEditDTO, Tag>(tag);
                var list = await GetTagsAsync();
                int contains = 0;
                foreach (var item in list)
                {
                    if (adding.Name.Contains(item.Name))
                    {
                        ++contains;
                    }
                }
                if (contains == 0)
                {
                    await tagRepository.AddAsync(adding);
                }
            }

        }
        public Tag PostDeleteFromTheTag(Tag tag, List<int> PostIds)
        {
            if (PostIds != null)
            {
                foreach (var post in PostIds)
                {
                    tag.PostTags.Remove(tag.PostTags.FirstOrDefault(i => i.PostId == post));
                }
            }
            return tag;
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
        public TagAddOrEditDTO GetEditTagsById(int id)
        {
            var result = tagRepository.GetTagsByIdWithPost(Types.PostTags,id);
            if (result == null) { return null; }
            var mapping = mapper.Map<Tag,TagAddOrEditDTO>(result);
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

        public async Task RemoveTagAsync(int id)
        {
            await tagRepository.DeleteAsync(id);
        }
        public IQueryable<TagListDTO> SearchTag(SearchDTO search)
        {
            var text = tagRepository.SearchTag(search.Text).ToList();
            var mapping= mapper.Map<List<TagListDTO>>(text);
            return mapping.AsQueryable();
        }
    }
}
