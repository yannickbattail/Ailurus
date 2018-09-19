using System;
using Ailurus.DTO.Implementation;
using Ailurus.Model;
using Ailurus.Model.Instructions;
using Ailurus.Service;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Model.Instructions
{
    public class MoveToTest
    {
        [Fact]
        public void TestGetStateAt()
        {
            var source = new CoordinateInt2D()
            {
                X = 1,
                Y = 1
            };
            var dest = new CoordinateInt2D()
            {
                X = 1,
                Y = 10
            };
            var drone = new Drone<CoordinateInt2D>(source)
            {
                Name = "someDrone",
                StorageSize = 10,
                Speed = 1
            };
            var dateStart = new DateTime(2018, 1, 1, 0,0,0);
            var date = new DateTime(2018, 1, 1, 0,0,4);
            var moveTo = new MoveTo<CoordinateInt2D>(drone,dateStart,source,dest);

            var actual = moveTo.GetPositionAt(date);
            
            var expected = new CoordinateInt2D()
            {
                X = 1,
                Y = 5
            }; 
            
            actual.Should().BeEquivalentTo(expected);
            
            

        }

        [Fact]
        public void TestDestinationEqualSource()
        {
            var source = new CoordinateInt2D()
            {
                X = 1,
                Y = 1
            };
            var drone = new Drone<CoordinateInt2D>(source)
            {
                Name = "someDrone",
                StorageSize = 10,
                Speed = 1
            };
            
            var dateStart = new DateTime(2018, 1, 1, 0,0,0);
            
            Action action = () =>
            {
                var move = new MoveTo<CoordinateInt2D>(drone,dateStart,source,source);
            };

            action.Should().Throw<InvalidInstructionException<CoordinateInt2D>>()
                .WithMessage("The drone is already at destination");

        }
    }
}