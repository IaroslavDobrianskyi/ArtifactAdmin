// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepServicetype.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Services
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using ModelsDTO;
    using ModelsDTO.FlowItems;

    public class ActionService : IActionService 
    {
        public List<int> RetrieveListOfActionResults(StepDto currentStepDto, StepDto lastStepDto)
        {
            return null;
        }

        public List<DesireDto> ApplyActionResultDesire(List<int> actionResults, List<DesireDto> desireList)
        {
            return null;
        }

        public int GenerateActionResult(StepDto step)
        {
            return 0;
        }

        public List<DesireDto> ApplyActionResultDesire(int actionResult, List<DesireDto> desireList)
        {
            return null;
        }
    }
}