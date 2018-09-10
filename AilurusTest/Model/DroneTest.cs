using System;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;
using Ailurus.Model.Instructions;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Repository
{
    public class DroneTest
    {
        [Fact]
        public void TestGetStateAt()
        {
            var drone = new Drone<CoordinateInt2D>(new CoordinateInt2D(){X=1,Y=1})
            {
                Name = "someDrone",
                StorageSize = 10,
                Speed = 10
            };
            var dateStart = new DateTime(2018, 1, 1, 0,0,0);
            drone.AddInstruction(new Unload<CoordinateInt2D>(drone, dateStart));
            
            var date1 = dateStart.Add(TimeSpan.FromSeconds(1));
            drone.GetStateAt(date1).Should().Be(DroneState.ExecutionInstruction);
            var date2 = dateStart.Add(TimeSpan.FromSeconds(drone.GetLastValidInstruction().Duration + 2));
            drone.GetStateAt(date2).Should().Be(DroneState.WaitingForOrders);
        }
    }
}