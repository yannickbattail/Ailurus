using System;
using System.ComponentModel;
using Ailurus.DTO.Implementation;
using Ailurus.Mapper.Implementation;
using Ailurus.Model;
using Ailurus.Model.Instructions;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Repository
{
    public class InstructionMapperTest
    {
        [Fact]
        public void TestCollectInstruction()
        {
            var drone = CreateDrone();
            
            var globalInstruction = new GlobalInstruction<CoordinateInt2D>()
            {
                TYPE = "Collect",
                Destination = null,
                DroneName = "Drone_1"
            };

            var mapper = new InstructionMapper<CoordinateInt2D>();
            var date = new DateTime(2018,1,1);

            var expectedInstruction = new Collect<CoordinateInt2D>(drone, date);
            
            
            var actualInstruction = mapper.ToSpecificInstruction(globalInstruction, drone, date);
            
            actualInstruction.Should().BeEquivalentTo(expectedInstruction);
        }
        
        [Fact]
        public void TestUnloadInstruction()
        {
            var drone = CreateDrone();
            
            var globalInstruction = new GlobalInstruction<CoordinateInt2D>()
            {
                TYPE = "Unload",
                Destination = null,
                DroneName = "Drone_1"
            };

            var mapper = new InstructionMapper<CoordinateInt2D>();
            var date = new DateTime(2018,1,1);

            var expectedInstruction = new Unload<CoordinateInt2D>(drone, date);
            
            
            var actualInstruction = mapper.ToSpecificInstruction(globalInstruction, drone, date);
            
            actualInstruction.Should().BeEquivalentTo(expectedInstruction);
        }
        
        [Fact]
        public void TestMoveToInstruction()
        {
            var drone = CreateDrone();
            
            var globalInstruction = new GlobalInstruction<CoordinateInt2D>()
            {
                TYPE = "MoveTo",
                Destination = new CoordinateInt2D(){X = 84,Y = 42},
                DroneName = "Drone_1"
            };

            var mapper = new InstructionMapper<CoordinateInt2D>();
            var date = new DateTime(2018,1,1);
            var dest = new CoordinateInt2D(){X = 84,Y = 42};
            var source = new CoordinateInt2D(){X = 1,Y = 1};
            var expectedInstruction = new MoveTo<CoordinateInt2D>(drone, date, source, dest);
            
            
            var actualInstruction = mapper.ToSpecificInstruction(globalInstruction, drone, date);
            
            actualInstruction.Should().BeEquivalentTo(expectedInstruction);
        }
        
        [Fact]
        public void TestMoveToInstructionFail()
        {
            var drone = CreateDrone();
            
            var globalInstruction = new GlobalInstruction<CoordinateInt2D>()
            {
                TYPE = "MoveTo",
                Destination = null,
                DroneName = "Drone_1"
            };

            var mapper = new InstructionMapper<CoordinateInt2D>();
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
            
            var globalInstruction = new GlobalInstruction<CoordinateInt2D>()
            {
                TYPE = "Poulet",
                Destination = null,
                DroneName = "Drone_1"
            };

            var mapper = new InstructionMapper<CoordinateInt2D>();
            var date = new DateTime(2018,1,1);
            
            Action toSpecificInstructionAction = () =>
            {
                mapper.ToSpecificInstruction(globalInstruction, drone, date);
            };

            toSpecificInstructionAction.Should().Throw<ArgumentException>()
                .WithMessage("Unknown instruction type Poulet");
        }
        
        private static Drone<CoordinateInt2D> CreateDrone()
        {
            var drone = new Drone<CoordinateInt2D>(new CoordinateInt2D(){X=1,Y=1})
            {
                Name = "Drone_1",
                Speed = 1,
                StorageSize = 10
            };
            return drone;
        }
    }
}