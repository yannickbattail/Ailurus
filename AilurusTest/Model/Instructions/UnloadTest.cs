using System;
using Ailurus.DTO.Implementation;
using Ailurus.Model;
using Ailurus.Model.Instructions;
using Ailurus.Service;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Model.Instructions
{
    public class UnloadTest
    {

        [Fact]
        public void TestNoMainBuilding()
        {
            var source = new CoordinateInt2D()
            {
                X = 10,
                Y = 10
            };
            var drone = new Drone(source)
            {
                Name = "someDrone",
                StorageSize = 10,
                Speed = 1
            };
            
            var dateStart = new DateTime(2018, 1, 1, 0,0,0);
            
            Action action = () =>
            {
                new Unload(drone, dateStart);
            };

            action.Should().Throw<InvalidInstructionException>()
                .WithMessage("No MainBuilding near the drone");

        }
    }
}