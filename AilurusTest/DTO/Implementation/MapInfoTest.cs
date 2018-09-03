using System;
using System.Collections.Generic;
using Ailurus.DTO.Implementation;
using Ailurus.Model;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Repository
{
    public class MapInfoTest
    {
        [Fact]
        public void AddResourceNewTest()
        {
            var cntx = new PlayerContext<CoordinateInt2D>()
            {
                Resources = new List<ResourceQuantity>()
            };

            var expected = new PlayerContext<CoordinateInt2D>()
            {
                Resources = new List<ResourceQuantity>()
                {
                    new ResourceQuantity()
                    {
                        Resource = ResourceType.Gold,
                        Quantity = 10
                    }
                }
            };
            
            cntx.AddResource( new ResourceQuantity()
            {
                Resource = ResourceType.Gold,
                Quantity = 10
            });

            cntx.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void AddResourceExistingTest()
        {
            var cntx = new PlayerContext<CoordinateInt2D>()
            {
                Resources = new List<ResourceQuantity>()
                {
                    new ResourceQuantity()
                    {
                        Resource = ResourceType.Gold,
                        Quantity = 21
                    }
                }
            };

            var expected = new PlayerContext<CoordinateInt2D>()
            {
                Resources = new List<ResourceQuantity>()
                {
                    new ResourceQuantity()
                    {
                        Resource = ResourceType.Gold,
                        Quantity = 42
                    }
                }
            };
            
            cntx.AddResource( new ResourceQuantity()
            {
                Resource = ResourceType.Gold,
                Quantity = 21
            });

            cntx.Should().BeEquivalentTo(expected);
        }
    }
}