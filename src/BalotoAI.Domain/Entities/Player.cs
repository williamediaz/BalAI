using System;
using System.Collections.Generic;

namespace BalotoAI.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Ticket> Tickets { get; set; } = new();
    }
}
