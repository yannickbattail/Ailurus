using System;
using Ailurus.DTO.Implementation;
using FluentAssertions;
using Xunit;

namespace AilurusTest.DTO.Implementation
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
        public void IsNearTest()
        {
            var source = new CoordinateInt2D()
            {
                X = 1,
                Y = 1
            };
            
            var dest = new CoordinateInt2D()
            {
                X = 3,
                Y = 4
            };
            var util = new CoordinateInt2DUtils();
            var near = util.IsNear(source, source);
            near.Should().BeTrue();
            near = util.IsNear(source, dest);
            near.Should().BeFalse();
        }
        [Fact]
        public void IsNearThrowTest()
        {
            var source = new CoordinateInt2D()
            {
                X = 1,
                Y = 1
            };
            
            var util = new CoordinateInt2DUtils();
            
            Action isNearAction = () =>
            {
                util.IsNear(source, null);
            };

            isNearAction.Should().Throw<ArgumentNullException>();
            
            isNearAction = () =>
            {
                util.IsNear(null, source);
            };

            isNearAction.Should().Throw<ArgumentNullException>();

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
        
        [Fact]
        public void ForceInsideOut2Test()
        {
            var coord = new CoordinateInt2D()
            {
                X = 1,
                Y = 1
            };
            
            var area = new Tuple<CoordinateInt2D, CoordinateInt2D>(
                new CoordinateInt2D()
                {
                    X = 5,
                    Y = 5
                }, new CoordinateInt2D()
                {
                    X = 10,
                    Y = 10
                }
            );
            
            var expected = new CoordinateInt2D()
            {
                X = 5,
                Y = 5
            };
            
            var util = new CoordinateInt2DUtils();
            var inside = util.ForceInside(coord, area);
            
            inside.Should().BeEquivalentTo(expected);
        }
                
        [Fact]
        public void PathProgressionTest()
        {
            var origin = new CoordinateInt2D()
            {
                X = 0,
                Y = 0
            };
            var destination = new CoordinateInt2D()
            {
                X = 10,
                Y = 10
            };
            
            var expected = new CoordinateInt2D()
            {
                X = 5,
                Y = 5
            };
            
            var util = new CoordinateInt2DUtils();
            var actual = util.PathProgression(origin, destination, 0.5);
            
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void PathProgressionNegativeTest()
        {
            var origin = new CoordinateInt2D()
            {
                X = 6,
                Y = 3
            };
            var destination = new CoordinateInt2D()
            {
                X = 0,
                Y = 0
            };
            
            var expected = new CoordinateInt2D()
            {
                X = 2,
                Y = 1
            };
            
            var util = new CoordinateInt2DUtils();
            var actual = util.PathProgression(origin, destination, 0.6666666);
            
            actual.Should().BeEquivalentTo(expected);
        }
   
        [Fact]
        public void PathProgressionWrongProgressionTest()
        {
            var origin = new CoordinateInt2D()
            {
                X = 6,
                Y = 3
            };
            var destination = new CoordinateInt2D()
            {
                X = 0,
                Y = 0
            };

            var util = new CoordinateInt2DUtils();
            
            Action pathProgressionAction = () =>
            {
                util.PathProgression(origin, destination, 2);
            };

            pathProgressionAction.Should().Throw<Exception>()
                .WithMessage("progression must be a percentage between 0 and 1 (including)");
        }   

    }
}