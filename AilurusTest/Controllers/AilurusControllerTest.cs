using System.Collections.Generic;
using Ailurus.Controllers;
using Ailurus.DTO.Requests.Implementations;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AilurusTest.Controllers
{
    public class AilurusControllerTest
    {
        [Fact]
        public void SendInstructionsTest()
        {
            var controller = new AilurusController();
            
            var instructionSet = new InstructionSetDto()
            {
                Login = new UserLoginDto()
                {
                    PlayerName = "panda",
                    Pass = "roux"
                },
                Instructions = new List<GlobalInstruction>()
                {
                    new GlobalInstruction{
                        TYPE = "Collect",
                        DroneName = "Drone_1",
                        Destination = null
                    },
                    new GlobalInstruction{
                        TYPE = "MoveTo",
                        DroneName = "Drone_2",
                        Destination = new CoordinateInt2D{
                            X = 10,
                            Y = 10
                        }
                    }
                }
            };

            ActionResult<IEnumerable<string>> expected = controller.Ok(new List<string>()
            {
                "Invalid Instruction: No mine near the drone for instruction: TYPE: Collect, DroneName: Drone_1, Destination: ",
                "OK, drone will do MoveTo"
            });
            controller.CreatePlayer(instructionSet.Login);
            var actual = controller.SendInstructions(instructionSet);
            
            actual.Should().BeEquivalentTo(expected);
        }
    }
}