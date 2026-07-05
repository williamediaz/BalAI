using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BalotoAI.Domain.Entities;
using BalotoAI.Domain.Repositories;
using BalotoAI.Infrastructure.Data;

namespace BalotoAI.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly BalotoDbContext _db;
        public TicketRepository(BalotoDbContext db) => _db = db;

        public async Task AddAsync(Ticket ticket)
        {
            _db.Tickets.Add(ticket);
            await _db.SaveChangesAsync();
        }

        public async Task<Ticket?> GetByIdAsync(System.Guid id) => await _db.Tickets.FindAsync(id);

        public async Task<IEnumerable<Ticket>> ListAsync() => await _db.Tickets.ToListAsync();
    }
}
