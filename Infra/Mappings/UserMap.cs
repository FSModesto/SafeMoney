using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);
            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);
            builder.Property(c => c.Password)
                .IsRequired();
            builder.Property(x => x.CreationDate)
              .IsRequired()
              .HasDefaultValueSql("GETDATE()");
        }
    }
}
