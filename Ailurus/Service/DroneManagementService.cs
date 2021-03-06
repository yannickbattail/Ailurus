﻿using System;
using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO.Requests.Implementations;
using Ailurus.DTO.Requests.Interfaces;
using Ailurus.Mapper.Implementations;
using Ailurus.Model;
using Ailurus.Repository;

namespace Ailurus.Service
{
    public class DroneManagementService<TCoordinate> where TCoordinate : ICoordinate
    {
        private IPlayerContext PlayerContext;
        private IPlayerContextRepository Repository;
        
        public DroneManagementService(string playerName)
        {
            Repository = AppService.GetAppService().GetPlayerContextRepository();
            PlayerContext = Repository.GetPlayerContextByPlayerName(playerName);
        }

        public IEnumerable<string> ProcessInstructions(IEnumerable<GlobalInstruction> instructions)
        {
            var messages = instructions.Select(
                ProcessInstruction
            );
            Repository.Save(PlayerContext);
            return messages;
        }
        
        private string ProcessInstruction(GlobalInstruction globInstruction)
        {
            try
            {
                var drone = PlayerContext.Drones.First(
                    dr => dr.Name == globInstruction.DroneName
                );
                if (drone.State == DroneState.ExecutionInstruction)
                {
                    return "drone is already doing an action "+drone.GetLastValidInstruction().GetType().Name;
                }

                var mapper = new InstructionMapper(PlayerContext);
                drone.AddInstruction(mapper.ToSpecificInstruction(globInstruction, drone, DateTime.Now));
                return "OK, drone will do "+drone.GetLastValidInstruction().GetType().Name;
            }
            catch (InvalidInstructionException e)
            {
                Console.WriteLine(e.Message);
                return "Invalid Instruction: " + e.Message + " for instruction: "+globInstruction;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return "no such drone named: " + globInstruction.DroneName;
            }
        }
    }
}