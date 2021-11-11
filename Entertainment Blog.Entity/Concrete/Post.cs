using System;
using System.Collections.Generic;

namespace Entertainment_Blog.Entity.Concrete
{
    public class Post:BaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Thumbnail { get; set; }
        public List<Contents> Contents { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public bool IsPublished { get; set; } = false;
        public ICollection<PostCategory> PostCategories { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public List<Comment> Comments { get; set; }

        //Identity özelliklerini ekledikten sonraa comment falan da eklersin!
        //public int ViewCount { get; set; }
        //public int LikeCount { get; set; }
        //public int CommentCount { get; set; }
    }
}
