using AspNetCoreAuthentication.DAL.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreAuthentication.DAL.Configurations
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasQueryFilter(f => EF.Property<DateTime?>(f, "DeletedDate") == null);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id);

            builder.Property(p => p.CreatedDate)
                .IsRequired(true);

            builder.Property(p => p.ModifiedDate)
                .IsRequired(true);

            builder.Property(p => p.DeletedDate)
                .IsRequired(false);
        }
    }
}
