using AspNetCoreAuthentication.DAL.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreAuthentication.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(f => EF.Property<DateTime?>(f, "DeletedDate") == null);

            builder.Property(p => p.FirstName)
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(p => p.LastName)
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(p => p.Email)
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(p => p.UserName)
                .HasMaxLength(64)
                .IsRequired(true);

            builder.Property(p => p.CreatedDate)
                .IsRequired(true);

            builder.Property(p => p.ModifiedDate)
                .IsRequired(true);

            builder.Property(p => p.DeletedDate)
                .IsRequired(false);
        }
    }
}
