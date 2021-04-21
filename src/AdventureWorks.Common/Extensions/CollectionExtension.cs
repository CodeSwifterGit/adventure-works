using System;
using System.Collections.Generic;

namespace AdventureWorks.Common.Extensions
{
    public static class CollectionExtension
    {
        public static void ForEach<T>(this ICollection<T> source, Action<T> action)
        {
            foreach (var element in source)
                action(element);
        }
    }
}