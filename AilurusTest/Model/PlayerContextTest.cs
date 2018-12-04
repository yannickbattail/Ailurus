using Ailurus.DTO.Requests.Implementations;
using Ailurus.Model;
using Ailurus.Model.Instructions;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AilurusTest.Model
{
    public class PlayerContextTest
    {
        [Fact]
        public void GetStoredResourcesAtVoidTest()
        {
            var cntx = new PlayerContext();

            IEnumerable<ResourceQuantity> expected = new List<ResourceQuantity>();

            var actual = cntx.Resources;
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetStoredResourcesAtTest()
        {
            var initPos = new CoordinateInt2D() { X = 4, Y = 4 };
            var rq = new ResourceQuantity() { Resource = ResourceType.Gold, Quantity = 42 };
            var cntx = new PlayerContext()
            {
                Level = 1
            };
            var mockedDrone = new Mock<IDrone>();
            mockedDrone
                .Setup(dr => dr.GetValidInstructions())
                .Returns(new List<IInstruction>()
                {
                    new Unload(cntx, new Drone(initPos), new DateTime(2018,1,1,0,0,0))
                    {
                        Resource = rq
                    }
                });

            cntx.Drones = new List<IDrone>()
            {
                mockedDrone.Object
            };
            IEnumerable<ResourceQuantity> expected = new List<ResourceQuantity>()
            {
                rq
            };

            var actual = cntx.Resources;
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetStoredResourcesAt3Test()
        {
            var initPos = new CoordinateInt2D() { X = 4, Y = 4 };
            var rq = new ResourceQuantity() { Resource = ResourceType.Gold, Quantity = 42 };
            var cntx = new PlayerContext()
            {
                Level = 1
            };
            var mockedDrone = new Mock<IDrone>();
            mockedDrone
                .Setup(dr => dr.GetValidInstructions())
                .Returns(new List<IInstruction>()
                {
                    new Unload(cntx, new Drone(initPos), new DateTime(2018,1,1,0,0,0))
                    {
                        Resource = new ResourceQuantity() {Resource = ResourceType.Gold, Quantity = 42}
                    },
                    new Unload(cntx, new Drone(initPos), new DateTime(2018,1,1,0,0,2))
                    {
                        Resource = new ResourceQuantity() {Resource = ResourceType.Silver, Quantity = 66}
                    }
                });
            var mockedDrone2 = new Mock<IDrone>();
            mockedDrone2
                .Setup(dr => dr.GetValidInstructions())
                .Returns(new List<IInstruction>()
                {
                    new Unload(cntx, new Drone(initPos), new DateTime(2018,1,1,0,0,0))
                    {
                        Resource = new ResourceQuantity() {Resource = ResourceType.Gold, Quantity = 42}
                    }
                });

            cntx.Drones = new List<IDrone>()
            {
                mockedDrone.Object,
                mockedDrone2.Object
            };
            IEnumerable<ResourceQuantity> expected = new List<ResourceQuantity>()
            {
                new ResourceQuantity() {Resource = ResourceType.Gold, Quantity = 84},
                new ResourceQuantity() {Resource = ResourceType.Silver, Quantity = 66}
            };

            var actual = cntx.Resources;
            var a = actual.ToList();
            a.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void IsGoalAchievedWithSuccess()
        {
            var initPos = new CoordinateInt2D() { X = 4, Y = 4 };
            var rq = new ResourceQuantity() { Resource = ResourceType.Gold, Quantity = 10 };
            var goal = new List<ResourceQuantity>()
            {
                new ResourceQuantity() {Resource = ResourceType.Gold, Quantity = 10}
            };
            var cntx = new PlayerContext()
            {
                Level = 1
            };
            var mockedDrone = new Mock<IDrone>();
            mockedDrone
                .Setup(dr => dr.GetValidInstructions())
                .Returns(new List<IInstruction>()
                {
                    new Unload(cntx, new Drone(initPos), new DateTime(2018,1,1,0,0,0))
                    {
                        Resource = rq
                    }
                });

            cntx.Drones = new List<IDrone>()
            {
                mockedDrone.Object
            };

            cntx.IsResourceGoalAchieved(goal).Should().BeTrue();
        }

        [Fact]
        public void IsGoalAchievedFail2Ressources()
        {
            var initPos = new CoordinateInt2D() { X = 4, Y = 4 };
            var rq = new ResourceQuantity() { Resource = ResourceType.Gold, Quantity = 10 };
            var goal = new List<ResourceQuantity>()
            {
                new ResourceQuantity() {Resource = ResourceType.Gold, Quantity = 10},
                new ResourceQuantity() {Resource = ResourceType.Silver, Quantity = 10}
            };
            var cntx = new PlayerContext()
            {
                Level = 1
            };
            var mockedDrone = new Mock<IDrone>();
            mockedDrone
                .Setup(dr => dr.GetValidInstructions())
                .Returns(new List<IInstruction>()
                {
                    new Unload(cntx, new Drone(initPos), new DateTime(2018,1,1,0,0,0))
                    {
                        Resource = rq
                    }
                });

            cntx.Drones = new List<IDrone>()
            {
                mockedDrone.Object
            };

            cntx.IsResourceGoalAchieved(goal).Should().BeFalse();
        }

        [Fact]
        public void IsGoalAchievedFailNotEnoughResources()
        {
            var initPos = new CoordinateInt2D() { X = 4, Y = 4 };
            var rq = new ResourceQuantity() { Resource = ResourceType.Gold, Quantity = 10 };
            var goal = new List<ResourceQuantity>()
            {
                new ResourceQuantity() {Resource = ResourceType.Gold, Quantity = 11},
            };
            var cntx = new PlayerContext()
            {
                Level = 1
            };
            var mockedDrone = new Mock<IDrone>();
            mockedDrone
                .Setup(dr => dr.GetValidInstructions())
                .Returns(new List<IInstruction>()
                {
                    new Unload(cntx, new Drone(initPos), new DateTime(2018,1,1,0,0,0))
                    {
                        Resource = rq
                    }
                });

            cntx.Drones = new List<IDrone>()
            {
                mockedDrone.Object
            };

            cntx.IsResourceGoalAchieved(goal).Should().BeFalse();
        }
    }
}