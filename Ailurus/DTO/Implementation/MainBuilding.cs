using Ailurus.DTO.Interfaces;

namespace Ailurus.DTO.Implementation
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
