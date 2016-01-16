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
    using System.Linq;

    using ArtifactAdmin.DAL.Models;

    using AutoMapper;

    using Interfaces;
    using ModelsDTO;
    using ModelsDTO.FlowItems;

    public class ActionService : IActionService 
    {
        private readonly IRepository<ActionResultDesire> actionResultDesireRepository;

        public ActionService(IRepository<ActionResultDesire> actionResultDesireRepository)
        {
            this.actionResultDesireRepository = actionResultDesireRepository;
        }

        public List<ActionResultDesireDto> RetrieveListOfActionResultDesires(List<StepDto> stepsList)
        {
            var stepIds = stepsList.Select(s => s.Id).ToList();
            var listActionResultDesires =
                actionResultDesireRepository.GetAll().Where(ar => stepIds.Contains(ar.ActionResult1.Action1.Step));
            return Mapper.Map<List<ActionResultDesireDto>>(listActionResultDesires);
        }

        public List<CarrierDesireDto> ApplyActionResultDesire(List<CarrierDesireDto> desireList, List<ActionResultDesireDto> actionResults)
        {
            var desireCount = desireList.Count;
            for (int i = 0; i < desireCount; i++)
            {
                desireList[i].Value -=
                    actionResults.Where(ar => ar.Desire == desireList[i].DesireId).Sum(ar => ar.Modifier);
            }

            return desireList;
        }

        public int GenerateActionResult(StepDto step)
        {
            return 0;
        }

        public List<DesireDto> ApplyActionResultDesire(List<DesireDto> desireList, List<ActionResultDesireDto> actionResults)
        {
            throw new NotImplementedException();
        }



        public List<DesireDto> ApplyActionResultDesire(int actionResult, List<DesireDto> desireList)
        {
            throw new NotImplementedException();
        }
    }
}