﻿using Ailurus.DTO.Requests.Interfaces;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Model;
using Ailurus.Model.Instructions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ailurus.DTO.Responses.Implementations
{
    public class DroneDto : IDroneDto
    {
        public string Name { get; set; }
        public IInstruction LastInstruction { get; set; }
        public ICoordinate CurrentPosition { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DroneState State { get; set; }
        public double Speed { get; set; }
        public int StorageSize{ get; set; }
        public ResourceQuantity Storage{ get; set; }
    }
}