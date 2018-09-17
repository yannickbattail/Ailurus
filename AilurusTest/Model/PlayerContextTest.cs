using System;
using System.Collections.Generic;
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
            var cntx = new PlayerContext<CoordinateInt2D>();
            
            IEnumerable<ResourceQuantity> expected = new List<ResourceQuantity>();

            var actual = cntx.Resources;
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void GetStoredResourcesAt2Test()
        {
            var initPos = new CoordinateInt2D() { X = 2, Y = 2};
            var rq = new ResourceQuantity() {Resource = ResourceType.Gold, Quantity = 42};
            var mockedDrone = new Mock<IDrone<CoordinateInt2D>>();
            mockedDrone
                .Setup(dr => dr.GetValidInstructions())
                .Returns(new List<IInstruction<CoordinateInt2D>>()
                {
                    new Unload<CoordinateInt2D>(new Drone<CoordinateInt2D>(initPos), new DateTime(2018,1,1,0,0,0))
                    {
                        Resource = rq
                    }
                });
            
            var cntx = new PlayerContext<CoordinateInt2D>()
            {
                Drones = new List<IDrone<CoordinateInt2D>>()
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
    }
}