using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdventureWorks.Application.DataEngine.DataEngine
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortDirection
    {
        [JsonProperty("ascending")] Ascending,
        [JsonProperty("descending")] Descending
    }
}