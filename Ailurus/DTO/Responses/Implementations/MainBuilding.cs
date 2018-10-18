using Ailurus.DTO.Requests.Interfaces;
using Ailurus.DTO.Responses.Interfaces;

namespace Ailurus.DTO.Responses.Implementations
{
    public class MainBuilding : IItem
    {
        public string TYPE
        {
            get { return this.GetType().Name; }
        }
        public string Name { get; set; }
        public ICoordinate Position { get; set; }
    }
}
