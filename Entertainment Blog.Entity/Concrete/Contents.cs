namespace Entertainment_Blog.Entity.Concrete
{
    public class Contents:BaseEntity
    {
        public string Text { get; set; }
        public string Image { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
    }
}
