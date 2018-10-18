using System;
using System.Collections.Generic;
using Ailurus.DTO.Requests.Implementations;
using Ailurus.Model;
using Ailurus.Model.Instructions;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Model
{
    public class DroneTest
    {
        [Fact]
        public void TestGetStateAt()
        {
            var drone = new Drone(new CoordinateInt2D(){X=2,Y=2})
            {
                Name = "someDrone",
                StorageSize = 10,
                Speed = 10
            };
            var dateStart = new DateTime(2018, 1, 1, 0,0,0);
            drone.AddInstruction(new Unload(drone, dateStart));
            
            var date1 = new DateTime(2018, 1, 1, 0,0,1);
            drone.GetStateAt(date1).Should().Be(DroneState.ExecutionInstruction);
            var date2  = new DateTime(2018, 1, 1, 0,0,6);
            drone.GetStateAt(date2).Should().Be(DroneState.WaitingForOrders);
        }
        
        [Fact]
        public void TestGetValidInstructions()
        {
            var drone = new Drone(new CoordinateInt2D(){X=2,Y=2})
            {
                Name = "someDrone",
                StorageSize = 10,
                Speed = 10
            };
            var dateStart = new DateTime(2018, 1, 1, 0,0,0);
            var unloadValid = new Unload(drone, dateStart);
            drone.AddInstruction(unloadValid);
            var unloadAborted = new Unload(drone, dateStart);
            unloadAborted.AbortedAt = dateStart;

            var expected = new List<IInstruction>(){unloadValid};
            
            var actual = drone.GetValidInstructions();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}