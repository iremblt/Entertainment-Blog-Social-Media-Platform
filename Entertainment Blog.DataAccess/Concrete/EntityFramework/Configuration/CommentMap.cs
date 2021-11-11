using Entertainment_Blog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Configuration
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(p => p.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(i => i.PostId);
            builder.HasOne(u => u.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(i => i.UserId);
            builder.Property(i => i.Message).IsRequired();
            builder.Property(i => i.Date).IsRequired();
        }
    }
}
