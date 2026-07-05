using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BalotoAI.Domain.Entities;
using BalotoAI.Domain.Repositories;
using BalotoAI.Infrastructure.Data;

namespace BalotoAI.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly BalotoDbContext _db;
        public PlayerRepository(BalotoDbContext db) => _db = db;

        public async Task AddAsync(Player player)
        {
            _db.Players.Add(player);
            await _db.SaveChangesAsync();
        }

        public async Task<Player?> GetByIdAsync(System.Guid id) => await _db.Players.FindAsync(id);

        public async Task<IEnumerable<Player>> ListAsync() => await _db.Players.ToListAsync();
    }
}
