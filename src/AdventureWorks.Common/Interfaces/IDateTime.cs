using System;

namespace AdventureWorks.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
    }
}