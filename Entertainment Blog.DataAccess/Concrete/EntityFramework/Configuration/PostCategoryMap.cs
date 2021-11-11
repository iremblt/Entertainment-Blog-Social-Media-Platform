using Entertainment_Blog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Configuration
{
    public class PostCategoryMap : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.HasKey(pc => new { pc.PostId, pc.CategoryId });
            builder.HasOne(p=>p.Post)
                .WithMany(pc=>pc.PostCategories)
                .HasForeignKey(p=>p.PostId);
            builder.HasOne(c => c.Category)
                .WithMany(pc => pc.PostCategories)
                .HasForeignKey(c => c.CategoryId);
        }
    }
}
