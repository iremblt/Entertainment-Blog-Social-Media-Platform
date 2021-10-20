using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfTagRepository:EfGenericRepository<Tag>,ITagRepository
    {
        public EfTagRepository(EntertainmentBlogContext context) : base(context)
        {
            
        }
        private List<Tag> IncludeTypes(Types types)
        {
            if (types.HasFlag(Types.PostTags))
            {
                context.Tags.Include(p => p.PostTags).ThenInclude(t => t.Tag).Load();
            }
            return context.Tags.ToList();
        }
        public Tag GetTagsByIdWithPost(Types types, int id)
        {
            var tag = IncludeTypes(types).ToList();
            var result = tag.FirstOrDefault(i => i.Id == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
            }
        }
        public List<Tag> GetTagsIncludePosts(Types types)
        {
            return IncludeTypes(types).ToList();
        }
        public IQueryable<Tag> SearchTag(String text)
        { 
            var tag = context.Tags.Where(i => i.Name.ToLower().Contains(text.ToLower()));
            return tag;
        }
    }
}
