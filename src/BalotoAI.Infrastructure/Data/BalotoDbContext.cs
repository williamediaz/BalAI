using Microsoft.EntityFrameworkCore;
using BalotoAI.Domain.Entities;
using System.Text.Json;

namespace BalotoAI.Infrastructure.Data
{
    public class BalotoDbContext : DbContext
    {
        public BalotoDbContext(DbContextOptions<BalotoDbContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Draw> Draws { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.CreatedAt).IsRequired();
                // Convert int[] to JSON string
                b.Property(p => p.Numbers)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, null),
                        v => JsonSerializer.Deserialize<int[]>(v) ?? new int[0]);
            });

            modelBuilder.Entity<Draw>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.DrawDate).IsRequired();
                b.Property(p => p.WinningNumbers)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, null),
                        v => JsonSerializer.Deserialize<int[]>(v) ?? new int[0]);
            });

            modelBuilder.Entity<Player>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Name).IsRequired();
            });
        }
    }
}
