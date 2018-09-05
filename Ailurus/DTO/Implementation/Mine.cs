using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.DTO.Implementation
{
    public class Mine<TCoordinate> : IItem<TCoordinate> where TCoordinate : ICoordinate
    {
        public string TYPE
        {
            get { return this.GetType().Name; }
        }
        public string Name { get; set; }
        public TCoordinate Position { get; set; }
        public ResourceType ResourceType  { get; set; }
    }
}
