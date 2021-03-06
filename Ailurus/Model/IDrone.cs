﻿using System;
using System.Collections.Generic;
using Ailurus.DTO.Requests.Interfaces;
using Ailurus.Model.Instructions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ailurus.Model
{
    public interface IDrone
    {
        string Name { get; set; }
        ICoordinate CurrentPosition { get; }
        [JsonConverter(typeof(StringEnumConverter))]
        DroneState State { get; }
        DroneState GetStateAt(DateTime time);
        Double Speed { get; set; }
        int StorageSize { get; set; }
        ResourceQuantity Storage { get; }
        IList<IInstruction> Instructions { get; set; }
        
        void AddInstruction(IInstruction instruction);
        void AbortLastInstruction();
        IEnumerable<IInstruction> GetInstructions();
        IEnumerable<IInstruction> GetValidInstructions();
        IInstruction GetLastValidInstruction();
    }
}