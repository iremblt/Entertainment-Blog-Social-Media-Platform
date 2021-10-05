using Entertainment_Blog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Map
{
    public class PostTagMap : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.HasKey(pt => new { pt.PostId, pt.TagId });
            builder.HasOne(p => p.Post)
                .WithMany(pt => pt.PostTags)
                .HasForeignKey(p => p.PostId);
            builder.HasOne(t => t.Tag)
                .WithMany(pt => pt.PostTags)
                .HasForeignKey(t => t.TagId);
        }
    }
}
