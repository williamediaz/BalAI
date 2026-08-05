using BalAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BalAI.Infrastructure.Persistence
{
    public class BalAIDbContext : DbContext
    {
        public BalAIDbContext(DbContextOptions<BalAIDbContext> options) : base(options) { }

        public DbSet<Balance> Balances { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Balance>(b => {
                b.HasKey(x => x.Id);
                b.Property(x => x.Amount).IsRequired();
                b.Property(x => x.CreatedAt).IsRequired();
            });
        }
    }
}
