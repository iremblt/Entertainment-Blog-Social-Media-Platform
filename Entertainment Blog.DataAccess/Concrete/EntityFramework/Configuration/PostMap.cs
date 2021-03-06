using Entertainment_Blog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Configuration
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(120);
            builder.Property(p => p.Thumbnail).IsRequired();
            builder.Property(p => p.PublishDate).IsRequired();
            builder.HasOne(u => u.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(i => i.UserId);
        }
    }
}
