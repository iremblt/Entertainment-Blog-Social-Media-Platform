namespace Entertainment_Blog.Entity.Concrete
{
    public class PostCategory
    {
        public Post Post { get; set; }
        public int PostId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
