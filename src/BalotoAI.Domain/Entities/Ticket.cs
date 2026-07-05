using System;
using System.Collections.Generic;

namespace BalotoAI.Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public int[] Numbers { get; set; } = Array.Empty<int>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
