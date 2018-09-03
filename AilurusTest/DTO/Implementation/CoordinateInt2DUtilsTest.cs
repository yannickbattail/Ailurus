using System;
using Ailurus.DTO.Implementation;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Repository
{
    public class CoordinateInt2DUtilsTest
    {
        [Fact]
        public void GetDistanceToTest()
        {
            var source = new CoordinateInt2D()
            {
                X = 0,
                Y = 0
            };
            
            var dest = new CoordinateInt2D()
            {
                X = 3,
                Y = 4
            };
            var util = new CoordinateInt2DUtils();
            var distance = util.GetDistanceTo(source, dest);
            
            distance.Should().Be(5);
        }
        
        [Fact]
        public void IsInsideTest()
        {
            var coord = new CoordinateInt2D()
            {
                X = 5,
                Y = 5
            };
            
            var area = new Tuple<CoordinateInt2D, CoordinateInt2D>(
                new CoordinateInt2D()
                {
                    X = 0,
                    Y = 0
                }, new CoordinateInt2D()
                {
                    X = 10,
                    Y = 10
                }
            );
            var util = new CoordinateInt2DUtils();
            var inside = util.IsInside(coord, area);
            
            inside.Should().BeTrue();
        }
        
        [Fact]
        public void IsInsideFalseTest()
        {
            var coord = new CoordinateInt2D()
            {
                X = 15,
                Y = 15
            };
            
            var area = new Tuple<CoordinateInt2D, CoordinateInt2D>(
                new CoordinateInt2D()
                {
                    X = 0,
                    Y = 0
                }, new CoordinateInt2D()
                {
                    X = 10,
                    Y = 10
                }
            );
            var util = new CoordinateInt2DUtils();
            var inside = util.IsInside(coord, area);
            
            inside.Should().BeFalse();
        }
        
        [Fact]
        public void ForceInsideTest()
        {
            var coord = new CoordinateInt2D()
            {
                X = 5,
                Y = 5
            };
            
            var area = new Tuple<CoordinateInt2D, CoordinateInt2D>(
                new CoordinateInt2D()
                {
                    X = 0,
                    Y = 0
                }, new CoordinateInt2D()
                {
                    X = 10,
                    Y = 10
                }
            );
            
            var expected = coord;
            
            var util = new CoordinateInt2DUtils();
            var inside = util.ForceInside(coord, area);
            
            inside.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public void ForceInsideOutTest()
        {
            var coord = new CoordinateInt2D()
            {
                X = 15,
                Y = 15
            };
            
            var area = new Tuple<CoordinateInt2D, CoordinateInt2D>(
                new CoordinateInt2D()
                {
                    X = 0,
                    Y = 0
                }, new CoordinateInt2D()
                {
                    X = 10,
                    Y = 10
                }
            );
            
            var expected = new CoordinateInt2D()
            {
                X = 10,
                Y = 10
            };
            
            var util = new CoordinateInt2DUtils();
            var inside = util.ForceInside(coord, area);
            
            inside.Should().BeEquivalentTo(expected);
        }
    }
}