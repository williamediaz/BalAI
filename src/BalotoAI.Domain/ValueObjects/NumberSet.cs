using System;
using System.Linq;
using System.Collections.Generic;

namespace BalotoAI.Domain.ValueObjects
{
    public record NumberSet
    {
        public int[] Numbers { get; init; } = Array.Empty<int>();

        public NumberSet(IEnumerable<int>? numbers)
        {
            Numbers = numbers?.ToArray() ?? Array.Empty<int>();
        }

        public bool Contains(int number) => Numbers.Contains(number);
    }
}
