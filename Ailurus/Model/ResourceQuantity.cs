using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ailurus.Model
{
    public class ResourceQuantity
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ResourceType Resource { get; set; }
        public int Quantity { get; set; }
    }
}