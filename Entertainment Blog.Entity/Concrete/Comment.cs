using System;

namespace Entertainment_Blog.Entity.Concrete
{
    public class Comment : BaseEntity
    {
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Post Post { get; set; }
        public int PostId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
