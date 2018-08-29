using Ailurus.Controllers;
using Ailurus.DTO.Implementation;
using Ailurus.Repository;
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
            var expected = AilurusController.CreateNew(playerName);
            repo.Save(expected);

            var playerActual = repo.GetPlayerContextByPlayerName(playerName);

            playerActual.Should().BeEquivalentTo(expected);
        }
    }
}