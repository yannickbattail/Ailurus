using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Mapper.Implementation;
using Ailurus.Model;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Repository
{
    public class PlayerContextMapperTest
    {
        [Fact]
        public void TestDroneMap()
        {
            var drone = new Drone<CoordinateInt2D>()
            {
                Name = "Drone_1",
                CurrentPosition = new CoordinateInt2D()
                {
                    X = 1,
                    Y = 1
                },
                LastInstruction = null,
                Speed = 1,
                StorageSize = 10,
                Storage = new ResourceQuantity()
                {
                    Quantity = 10,
                    Resource = ResourceType.Gold
                }
            };
            
            var droneDtoExpected = new DroneDto<CoordinateInt2D>()
            {
                Name = "Drone_1",
                CurrentPosition = new CoordinateInt2D()
                {
                    X = 1,
                    Y = 1
                },
                LastInstruction = null,
                State = DroneState.WaitingForOrders,
                Speed = 1,
                StorageSize = 10,
                Storage = new ResourceQuantity()
                {
                    Quantity = 10,
                    Resource = ResourceType.Gold
                }
            };

            var mapper = new PlayerContextMapper<CoordinateInt2D>();
            
            var droneDtoActual = mapper.Map(drone);
            
            droneDtoActual.Should().BeEquivalentTo(droneDtoExpected);
        }
    }
}