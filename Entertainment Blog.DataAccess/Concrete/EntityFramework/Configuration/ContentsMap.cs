using Entertainment_Blog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Map
{
    public class ContentsMap : IEntityTypeConfiguration<Contents>
    {
        public void Configure(EntityTypeBuilder<Contents> builder)
        {
            builder.HasOne(p => p.Post)
                .WithMany(i => i.Contents)
                .HasForeignKey(c => c.PostId);
        }
    }
}
