using Ailurus.DTO.Requests.Interfaces;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Model;

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
        public ResourceType ResourceType  { get; set; }
    }
}
