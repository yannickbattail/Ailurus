namespace Ailurus.DTO.Interfaces
{
    public interface IItem
    {
        string TYPE { get; }
        string Name { get; set; }
        ICoordinate Position { get; set; }
    }
}