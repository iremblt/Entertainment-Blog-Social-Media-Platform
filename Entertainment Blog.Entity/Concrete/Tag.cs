using System.Collections.Generic;

namespace Entertainment_Blog.Entity.Concrete
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
    }
}
