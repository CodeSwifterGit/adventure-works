using System.Collections.Generic;

namespace AdventureWorks.Application.DataEngine.DataEngine
{
    public class FilteringInfo
    {
        public string Query { get; set; }
        public List<object> Parameters { get; set; }
    }
}