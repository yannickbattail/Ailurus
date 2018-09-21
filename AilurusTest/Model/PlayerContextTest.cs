using System;
using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO.Implementation;
using Ailurus.Model;
using Ailurus.Model.Instructions;
using FluentAssertions;
using Xunit;
using Moq;

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
            var initPos = new CoordinateInt2D() { X = 2, Y = 2};
            var rq = new ResourceQuantity() {Resource = ResourceType.Gold, Quantity = 42};
            var mockedDrone = new Mock<IDrone>();
            mockedDrone
                .Setup(dr => dr.GetValidInstructions())
                .Returns(new List<IInstruction>()
                {
                    new Unload(new Drone(initPos), new DateTime(2018,1,1,0,0,0))
                    {
                        Resource = rq
                    }
                });
            
            var cntx = new PlayerContext()
            {
                Drones = new List<IDrone>()
                {
                    mockedDrone.Object
                }
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
            var initPos = new CoordinateInt2D() { X = 2, Y = 2};
            var rq = new ResourceQuantity() {Resource = ResourceType.Gold, Quantity = 42};
            var mockedDrone = new Mock<IDrone>();
            mockedDrone
                .Setup(dr => dr.GetValidInstructions())
                .Returns(new List<IInstruction>()
                {
                    new Unload(new Drone(initPos), new DateTime(2018,1,1,0,0,0))
                    {
                        Resource = new ResourceQuantity() {Resource = ResourceType.Gold, Quantity = 42}
                    },
                    new Unload(new Drone(initPos), new DateTime(2018,1,1,0,0,2))
                    {
                        Resource = new ResourceQuantity() {Resource = ResourceType.Silver, Quantity = 66}
                    }
                });
            var mockedDrone2 = new Mock<IDrone>();
            mockedDrone2
                .Setup(dr => dr.GetValidInstructions())
                .Returns(new List<IInstruction>()
                {
                    new Unload(new Drone(initPos), new DateTime(2018,1,1,0,0,0))
                    {
                        Resource = new ResourceQuantity() {Resource = ResourceType.Gold, Quantity = 42}
                    }
                });

            var cntx = new PlayerContext()
            {
                Drones = new List<IDrone>()
                {
                    mockedDrone.Object,
                    mockedDrone2.Object
                }
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
    }
}