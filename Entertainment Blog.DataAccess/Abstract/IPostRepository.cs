using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using System.Collections.Generic;

namespace Entertainment_Blog.DataAccess.Abstract
{
    public interface IPostRepository:IGenericRepository<Post>
    {
        List<Post> GetPostsIncludeCategoriesAndTags(Types types);
        Post GetPostByIdWithCategoriesAndTags(Types types,int id);
    }
}
