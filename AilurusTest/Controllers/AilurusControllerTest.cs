using System.Collections.Generic;
using Ailurus.Controllers;
using Ailurus.DTO.Implementation;
using Xunit;
using FluentAssertions;

namespace AilurusTest
{
    public class AilurusControllerTest
    {
        [Fact]
        public void SendInstructionsTest()
        {
            var controller = new AilurusController();
            var instructions = new List<GlobalInstruction<CoordinateInt2D>>()
            {
                new GlobalInstruction<CoordinateInt2D>{
                    TYPE = "Collect",
                    DroneName = "Drone_1",
                    Destination = null
                },
                new GlobalInstruction<CoordinateInt2D>{
                    TYPE = "MoveTo",
                    DroneName = "Drone_2",
                    Destination = new CoordinateInt2D{
                        X = 10,
                        Y = 10
                    }
                }
            };

            var expected = new List<string>()
            {
                "OK, drone will do Collect`1",
                "OK, drone will do MoveTo`1"
            };
            controller.GetPlayerContext();
            var actual = controller.SendInstructions(instructions);
            
            actual.Should().BeEquivalentTo(expected);
        }
    }
}