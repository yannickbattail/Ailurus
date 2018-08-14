namespace Ailurus.DTO
{
    public interface IItem<TCoordinate> where TCoordinate : ICoordinate
    {
        string TYPE { get; }
        string Name { get; set; }
        TCoordinate Position { get; set; }
    }
}