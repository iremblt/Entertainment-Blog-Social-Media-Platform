using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entertainment_Blog.DataAccess.Abstract
{
    public interface IPostRepository:IGenericRepository<Post>
    {
        List<Post> GetPostsIncludeCategoriesAndTags(Types types);
        Post GetPostByIdWithCategoriesAndTags(Types types,int id);
        IQueryable<Post> GetPostsOrderByDate();
        IQueryable<Post> SearchPost(String text);
        Task<Post> AddCategoryForPost(Post post, List<int> CategoryIds);
        Task<Post> AddTagForPost(Post post, List<int> TagIds);

    }
}
