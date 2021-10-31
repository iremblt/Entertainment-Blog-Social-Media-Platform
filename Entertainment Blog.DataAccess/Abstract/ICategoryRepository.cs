using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using System.Collections.Generic;

namespace Entertainment_Blog.DataAccess.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        List<Category> GetCategoriesIncludePosts(Types types);
        Category GetCategoryByIdWithPost(Types types,int id);
        Category GetAddOrEditCategoryByIdWithPost(int id);
    }
}
