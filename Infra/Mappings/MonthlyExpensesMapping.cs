using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Mappings
{
    public class MonthlyExpensesMapping : IEntityTypeConfiguration<MonthlyExpenses>
    {
        public void Configure(EntityTypeBuilder<MonthlyExpenses> builder)
        {
            builder.ToTable("MonthlyExpenses");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Month)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);
            builder.Property(p => p.Limit)
                .IsRequired()
                .HasColumnType("DECIMAL(18,2)");
            builder.Property(p => p.Total)
                .IsRequired()
                .HasColumnType("DECIMAL(18,2)");
            builder.HasOne(e => e.Status)
                .WithMany()
                .HasForeignKey(e => e.StatusId)
                .HasConstraintName("FKStatusMonthlyExpenses")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
