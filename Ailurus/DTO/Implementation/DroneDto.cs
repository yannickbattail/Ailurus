﻿using Ailurus.DTO.Interfaces;
using Ailurus.Model;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Implementation
{
    public class DroneDto : IDroneDto
    {
        public string Name { get; set; }
        public IInstruction LastInstruction { get; set; }
        public ICoordinate CurrentPosition { get; set; }
        public DroneState State { get; set; }
        public double Speed { get; set; }
        public int StorageSize{ get; set; }
        public ResourceQuantity Storage{ get; set; }
    }
}