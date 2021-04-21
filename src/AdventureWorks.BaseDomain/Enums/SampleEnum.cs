using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace AdventureWorks.BaseDomain.Enums
{
    // Note: It is strictly forbidden to change the order or value of enum members
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SampleEnum
    {
        X,
        Y
    }
}
