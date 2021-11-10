using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Entertainment_Blog.Entity.Concrete;
using Entertainment_Blog.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCategoryRepository:EfGenericRepository<Category>,ICategoryRepository
    {
        public EfCategoryRepository(EntertainmentBlogContext context) : base(context)
        {
        }
        private List<Category> IncludeTypes(Types types)
        {
            if (types.HasFlag(Types.PostCategories))
            {
                context.Categories.Include(c => c.PostCategories).ThenInclude(i => i.Post).Load();
            }
            return context.Categories.ToList();
        }
        public List<Category> GetCategoriesIncludePosts(Types types)
        {
            var lists = IncludeTypes(types).ToList();
            return lists;
        }

        public Category GetCategoryByIdWithPost(Types types,int id)
        {
            var category = IncludeTypes(types).ToList();
            var result = category.FirstOrDefault(i => i.Id == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                return result;
                
            }
        }  
    }
}
