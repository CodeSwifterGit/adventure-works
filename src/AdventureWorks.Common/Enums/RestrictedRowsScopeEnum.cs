using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdventureWorks.Common.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RestrictedRowsScopeEnum
    {
        AllRows,
        OwnerOnly
    }
}