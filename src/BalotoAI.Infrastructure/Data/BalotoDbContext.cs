using Microsoft.EntityFrameworkCore;
using BalotoAI.Domain.Entities;

namespace BalotoAI.Infrastructure.Data
{
    public class BalotoDbContext : DbContext
    {
        public BalotoDbContext(DbContextOptions<BalotoDbContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.CreatedAt).IsRequired();
            });
        }
    }
}
