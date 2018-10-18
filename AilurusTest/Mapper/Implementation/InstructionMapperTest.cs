using System;
using Ailurus.DTO.Requests.Implementations;
using Ailurus.Mapper.Implementations;
using Ailurus.Model;
using Ailurus.Model.Instructions;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Mapper.Implementation
{
    public class InstructionMapperTest
    {
        [Fact]
        public void TestCollectInstruction()
        {
            var drone = new Drone(new CoordinateInt2D(){X=98,Y=98})
            {
                Name = "Drone_1",
                Speed = 1,
                StorageSize = 10
            };
            
            var globalInstruction = new GlobalInstruction()
            {
                TYPE = "Collect",
                Destination = null,
                DroneName = "Drone_1"
            };

            var mapper = new InstructionMapper();
            var date = new DateTime(2018,1,1);

            var expectedInstruction = new Collect(drone, date);
            
            
            var actualInstruction = mapper.ToSpecificInstruction(globalInstruction, drone, date);
            
            actualInstruction.Should().BeEquivalentTo(expectedInstruction);
        }
        
        [Fact]
        public void TestUnloadInstruction()
        {
            var drone = new Drone(new CoordinateInt2D(){X=2,Y=2})
            {
                Name = "Drone_1",
                Speed = 1,
                StorageSize = 10
            };

            
            var globalInstruction = new GlobalInstruction()
            {
                TYPE = "Unload",
                Destination = null,
                DroneName = "Drone_1"
            };

            var mapper = new InstructionMapper();
            var date = new DateTime(2018,1,1);

            var expectedInstruction = new Unload(drone, date);
            
            
            var actualInstruction = mapper.ToSpecificInstruction(globalInstruction, drone, date);
            
            actualInstruction.Should().BeEquivalentTo(expectedInstruction);
        }
        
        [Fact]
        public void TestMoveToInstruction()
        {
            var drone = CreateDrone();
            
            var date = new DateTime(2018,1,1);
            var dest = new CoordinateInt2D(){X = 84,Y = 42};
            var source = new CoordinateInt2D(){X = 1,Y = 1};
            
            var globalInstruction = new GlobalInstruction()
            {
                TYPE = "MoveTo",
                Destination = dest,
                DroneName = "Drone_1"
            };

            var mapper = new InstructionMapper();
            var expectedInstruction = new MoveTo(drone, date, source, dest);
            
            
            var actualInstruction = mapper.ToSpecificInstruction(globalInstruction, drone, date);
            
            actualInstruction.Should().BeEquivalentTo(expectedInstruction);
        }
        
        [Fact]
        public void TestMoveToInstructionFail()
        {
            var drone = CreateDrone();
            
            var globalInstruction = new GlobalInstruction()
            {
                TYPE = "MoveTo",
                Destination = null,
                DroneName = "Drone_1"
            };

            var mapper = new InstructionMapper();
            var date = new DateTime(2018,1,1);
            
            Action toSpecificInstructionAction = () =>
            {
                mapper.ToSpecificInstruction(globalInstruction, drone, date);
            };

            toSpecificInstructionAction.Should().Throw<ArgumentException>()
                .WithMessage("missing destination for MoveTo instruction");
        }
                
        [Fact]
        public void TestUnknownInstruction()
        {
            var drone = CreateDrone();
            
            var globalInstruction = new GlobalInstruction()
            {
                TYPE = "Poulet",
                Destination = null,
                DroneName = "Drone_1"
            };

            var mapper = new InstructionMapper();
            var date = new DateTime(2018,1,1);
            
            Action toSpecificInstructionAction = () =>
            {
                mapper.ToSpecificInstruction(globalInstruction, drone, date);
            };

            toSpecificInstructionAction.Should().Throw<ArgumentException>()
                .WithMessage("Unknown instruction type Poulet");
        }
        
        private static Drone CreateDrone()
        {
            var drone = new Drone(new CoordinateInt2D(){X=1,Y=1})
            {
                Name = "Drone_1",
                Speed = 1,
                StorageSize = 10
            };
            return drone;
        }
    }
}