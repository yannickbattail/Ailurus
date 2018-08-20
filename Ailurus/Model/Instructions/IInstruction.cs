﻿using System;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public interface IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        IDrone<TCoordinate> Drone { get; set; }
        DateTime StartedAt { get; set; }
        DateTime EndAt { get; }
    }
}