using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.Mappings
{
    public class ExpensesMap : IEntityTypeConfiguration<Expenses>
    {
        public void Configure(EntityTypeBuilder<Expenses> builder)
        {
            builder.ToTable("Expenses");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);
            builder.Property(p => p.Value)
                .IsRequired()
                    .HasColumnType("DECIMAL(18,2)");
            builder.Property(x => x.Date)
              .IsRequired()
              .HasDefaultValueSql("GETDATE()");
            builder.HasOne(e => e.User)
              .WithMany(e => e.Expenses)
              .HasForeignKey(e => e.UserId)
              .HasConstraintName("FKUserExpenses")
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
