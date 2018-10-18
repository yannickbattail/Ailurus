using Ailurus.DTO.Requests.Interfaces;

namespace Ailurus.DTO.Responses.Interfaces
{
    public interface IItem
    {
        string TYPE { get; }
        string Name { get; set; }
        ICoordinate Position { get; set; }
    }
}