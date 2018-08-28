using System;
using Ailurus.DTO.Interfaces;
using Ailurus.Repository;

namespace Ailurus.Model.Instructions
{
    public class Collect<TCoordinate> : AbstractInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public override DateTime EndAt
        {
            get
            {
                return StartedAt.AddSeconds(Duration);
            }
            protected set{}
        }

        public override double Duration
        {
            get
            {
                return 5;
            }
            protected set{}
        }

        public Collect(IDrone<TCoordinate> drone, DateTime startedAt)
        {
            Drone = drone;
            StartedAt = startedAt;
        }

        protected override void JustDoIt(string playerName)
        {
            var repo = new PlayerContextRepository<TCoordinate>();
            var playerContext = repo.GetPlayerContextByPlayerName(playerName);
            Drone.Storage = new ResourceQuantity()
            {
                Resource = ResourceType.Gold,
                Quantity = Drone.StorageSize
            };
            repo.Save(playerContext);
        }
    }
}
