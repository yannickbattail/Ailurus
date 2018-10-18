using Ailurus.DTO.Requests.Implementations;
using Ailurus.DTO.Responses.Implementations;
using Ailurus.Mapper.Implementations;
using Ailurus.Model;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Mapper.Implementation
{
    public class PlayerContextMapperTest
    {
        [Fact]
        public void TestDroneMap()
        {
            var drone = new Drone(new CoordinateInt2D(){X=1,Y=1})
            {
                Name = "Drone_1",
                Speed = 1,
                StorageSize = 10
            };
            
            var droneDtoExpected = new DroneDto()
            {
                Name = "Drone_1",
                CurrentPosition = new CoordinateInt2D()
                {
                    X = 1, Y = 1
                },
                LastInstruction = null,
                State = DroneState.WaitingForOrders,
                Speed = 1,
                StorageSize = 10,
                Storage = null
            };

            var mapper = new PlayerContextMapper();
            
            var droneDtoActual = mapper.Map(drone);
            
            droneDtoActual.Should().BeEquivalentTo(droneDtoExpected);
        }
    }
}