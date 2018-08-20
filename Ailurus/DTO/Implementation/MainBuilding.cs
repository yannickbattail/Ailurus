using Ailurus.DTO.Interfaces;

namespace Ailurus.DTO.Implementation
{
    public class MainBuilding<TCoordinate> : IItem<TCoordinate> where TCoordinate : ICoordinate
    {
        public string TYPE
        {
            get { return this.GetType().Name; }
        }
        public string Name { get; set; }
        public TCoordinate Position { get; set; }
    }
}
