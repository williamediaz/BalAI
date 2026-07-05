using System;

namespace BalotoAI.Domain.Entities
{
    public class Draw
    {
        public Guid Id { get; set; }
        public int[] WinningNumbers { get; set; } = Array.Empty<int>();
        public DateTime DrawDate { get; set; } = DateTime.UtcNow;
    }
}
