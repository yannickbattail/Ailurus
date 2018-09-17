using System.Collections.Generic;
using Ailurus.Controllers;
using Ailurus.DTO.Implementation;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Controllers
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
                "Invalid Instruction: No mine near the drone for instruction: TYPE: Collect, DroneName: Drone_1, Destination: ",
                "OK, drone will do MoveTo`1"
            };
            controller.GetPlayerContext();
            var actual = controller.SendInstructions(instructions);
            
            actual.Should().BeEquivalentTo(expected);
        }
    }
}