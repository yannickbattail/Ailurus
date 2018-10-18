using System;
using Ailurus.DTO.Requests.Implementations;
using FluentAssertions;
using Xunit;

namespace AilurusTest.DTO.Implementation
{
    public class CoordinateInt2DTest
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
            var distance = source.GetDistanceTo(dest);
            
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
            var near = source.IsNear(source);
            near.Should().BeTrue();
            near = source.IsNear(dest);
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
            
            Action isNearAction = () =>
            {
                source.IsNear(null);
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
            var inside = coord.IsInside(area);
            
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
            var inside = coord.IsInside(area);
            
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
            
            var inside = coord.ForceInside(area);
            
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
            
            var inside = coord.ForceInside(area);
            
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
            
            var inside = coord.ForceInside(area);
            
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
            
            var actual = origin.PathProgression(destination, 0.5);
            
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
            
            var actual = origin.PathProgression(destination, 0.6666666);
            
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
            
            Action pathProgressionAction = () =>
            {
                origin.PathProgression(destination, 2);
            };

            pathProgressionAction.Should().Throw<Exception>()
                .WithMessage("progression must be a percentage between 0 and 1 (including)");
        }   

    }
}