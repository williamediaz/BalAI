using System;
using System.Collections.Generic;

namespace BalotoAI.Domain.Entities
{
    public class Statistic
    {
        public Guid Id { get; set; }
        public int TotalDraws { get; set; }
        public Dictionary<int, int> NumberFrequencies { get; set; } = new();
    }
}
