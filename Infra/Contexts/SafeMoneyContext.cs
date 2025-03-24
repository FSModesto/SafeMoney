using Domain.Entities;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexts
{
    public class SafeMoneyContext : DbContext
    {
        public SafeMoneyContext(DbContextOptions<SafeMoneyContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Expenses> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ExpensesMap());
            modelBuilder.ApplyConfiguration(new MonthlyExpensesMapping());
            modelBuilder.Entity<Categorys>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Name);
            });
            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Name);
            });
        }
    }
}
