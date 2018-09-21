using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.DTO.Implementation
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
