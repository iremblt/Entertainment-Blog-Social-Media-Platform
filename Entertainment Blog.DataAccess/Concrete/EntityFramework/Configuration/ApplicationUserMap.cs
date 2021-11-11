using Entertainment_Blog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entertainment_Blog.DataAccess.Concrete.EntityFramework.Configuration
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(120);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(130);
            builder.Property(u => u.PasswordHash).IsRequired();
        }
    }
}
