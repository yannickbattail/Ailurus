using Ailurus.DTO.Requests.Implementations;
using Ailurus.Model;
using Ailurus.Repository;
using FluentAssertions;
using System.Collections.Generic;
using Ailurus.Model.Instructions;
using Xunit;

namespace AilurusTest.Repository
{
    public class PlayerContextRepositoryTest
    {
        [Fact]
        public void TestSaveLoad()
        {
            var repo = new PlayerContextRepository();
            var playerName = "somePlayer";
            var expected = new PlayerContext()
            {
                PlayerName = playerName,
                Pass = "somePlayer",
                Level = 1,
                Drones = new List<IDrone>()
                {
                    new Drone()
                    {
                        Name = "droneTest",
                        Speed = 10,
                        StorageSize = 10,
                        InitialPosition = new CoordinateInt2D() { X = 1, Y = 2 },
                    }
                }
            };
            repo.Save(expected);

            var playerActual = repo.GetPlayerContextByPlayerName(playerName);

            playerActual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void TestSaveLoadFile()
        {
            var repo = new PlayerContextFileRepository();
            var playerName = "somePlayer";
            var expected = new PlayerContext()
            {
                PlayerName = playerName,
                Pass = "somePlayer",
                Level = 1,
                Drones = new List<IDrone>()
                {
                    new Drone()
                    {
                        Name = "droneTest",
                        Speed = 10,
                        StorageSize = 10,
                        InitialPosition = new CoordinateInt2D() { X = 1, Y = 2 },
                        Instructions = new List<IInstruction>()
                    }
                }
            };
            repo.Save(expected);

            var playerActual = repo.GetPlayerContextByPlayerName(playerName);

            playerActual.Should().BeEquivalentTo(expected);
        }
    }
}