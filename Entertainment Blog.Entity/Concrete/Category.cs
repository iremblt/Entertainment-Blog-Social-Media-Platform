using System.Collections.Generic;

namespace Entertainment_Blog.Entity.Concrete
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; }
    }
}
