using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdventureWorks.Application.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CrudActionEnum
    {
        Create,
        Delete,
        Update
    }
}