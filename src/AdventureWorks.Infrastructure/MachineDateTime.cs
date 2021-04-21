using System;
using AdventureWorks.Common.Interfaces;

namespace AdventureWorks.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}