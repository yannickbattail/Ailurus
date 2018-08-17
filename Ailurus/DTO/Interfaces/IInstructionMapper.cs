using Ailurus.DTO.Implementation.DroneInstruction;

namespace Ailurus.DTO
{
    public interface IInstructionMapper<TCoordinate> where TCoordinate : ICoordinate
    {
        IDroneInstruction<TCoordinate> ToSpecificInstruction(GlobalInstruction<TCoordinate> globalInstruction);
    }
}