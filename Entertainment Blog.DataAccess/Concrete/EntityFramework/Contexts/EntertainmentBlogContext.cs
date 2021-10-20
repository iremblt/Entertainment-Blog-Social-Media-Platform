using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Map;
using Entertainment_Blog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts
{
    public class EntertainmentBlogContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EBSMPDB;integrated security=true;") ;
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Contents> Contents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostCategoryMap());
            modelBuilder.ApplyConfiguration(new PostTagMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new TagMap());
            modelBuilder.ApplyConfiguration(new ContentsMap());
        }
    }
}
