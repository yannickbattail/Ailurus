using Ailurus.DTO.Implementation;
using Ailurus.Repository;
using Ailurus.Service;
using FluentAssertions;
using Xunit;

namespace AilurusTest.Repository
{
    public class PlayerContextRepositoryTest
    {
        [Fact]
        public void TestSaveLoad()
        {
            var repo = new PlayerContextRepository<CoordinateInt2D>();
            var playerName = "somePlayer";
            var expected = AppService<CoordinateInt2D>.GetAppService().CreateNew(playerName);
            repo.Save(expected);

            var playerActual = repo.GetPlayerContextByPlayerName(playerName);

            playerActual.Should().BeEquivalentTo(expected);
        }
    }
}