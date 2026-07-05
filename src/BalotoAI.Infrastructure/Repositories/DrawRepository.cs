using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BalotoAI.Domain.Entities;
using BalotoAI.Domain.Repositories;
using BalotoAI.Infrastructure.Data;

namespace BalotoAI.Infrastructure.Repositories
{
    public class DrawRepository : IDrawRepository
    {
        private readonly BalotoDbContext _db;
        public DrawRepository(BalotoDbContext db) => _db = db;

        public async Task AddAsync(Draw draw)
        {
            _db.Draws.Add(draw);
            await _db.SaveChangesAsync();
        }

        public async Task<Draw?> GetByIdAsync(System.Guid id) => await _db.Draws.FindAsync(id);

        public async Task<IEnumerable<Draw>> ListAsync() => await _db.Draws.ToListAsync();
    }
}
