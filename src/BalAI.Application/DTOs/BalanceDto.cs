using System;

namespace BalAI.Application.DTOs
{
    public class BalanceDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
