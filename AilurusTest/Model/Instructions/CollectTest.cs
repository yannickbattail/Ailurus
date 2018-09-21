using System;
using Ailurus.DTO.Implementation;
using Ailurus.Model;
using Ailurus.Model.Instructions;
using Ailurus.Service;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Model.Instructions
{
    public class CollectTest
    {

        [Fact]
        public void testNoMine()
        {
            var source = new CoordinateInt2D()
            {
                X = 1,
                Y = 1
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
                new Collect(drone, dateStart);
            };

            action.Should().Throw<InvalidInstructionException>()
                .WithMessage("No mine near the drone");

        }
    }
}