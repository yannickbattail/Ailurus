using Ailurus.DTO.Requests.Interfaces;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ailurus.DTO.Responses.Implementations
{
    public class Mine : IItem
    {
        public string TYPE
        {
            get { return this.GetType().Name; }
        }
        public string Name { get; set; }
        public ICoordinate Position { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ResourceType ResourceType  { get; set; }
    }
}
