using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entertainment_Blog.DataAccess.Abstract
{
    public interface ITagRepository:IGenericRepository<Tag>
    {
        List<Tag> GetTagsIncludePosts(Types types);
        Tag GetTagsByIdWithPost(Types types,int id);
        IQueryable<Tag> SearchTag(String text);
    }
}
