using Ailurus.DTO.Implementation;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Repository
{
    public class CoordinateInt2DTest
    {
        [Fact]
        public void TestGetStateAt()
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
    }
}