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
        private readonly IRepository<ActionTemplate> actionTemplateRepository;
        private readonly IRepository<DesireActionTemplateResult> desireActionTemplateResultRepository;
        private readonly IRepository<ArtifactAdmin.DAL.Models.Action> actionRepository;
        private readonly IRepository<ArtifactAdmin.DAL.Models.ActionResult> actionResultRepository;

        private readonly StepService stepService;

        public ActionService(
            IRepository<ActionResultDesire> actionResultDesireRepository,
            IRepository<ActionTemplate> actionTemplateRepository,
            IRepository<DesireActionTemplateResult> desireActionTemplateResultRepository,
            IRepository<ArtifactAdmin.DAL.Models.Action> actionRepository,
            StepService stepService,
            IRepository<ArtifactAdmin.DAL.Models.ActionResult> actionResultRepository)
        {
            this.actionResultDesireRepository = actionResultDesireRepository;
            this.actionTemplateRepository = actionTemplateRepository;
            this.desireActionTemplateResultRepository = desireActionTemplateResultRepository;
            this.actionRepository = actionRepository;
            this.stepService = stepService;
            this.actionResultRepository = actionResultRepository;
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

        public object GenerateActions(StepDto step, StepCreationInfo stepInfo)
        {
            var actionTemplates = this.actionTemplateRepository.GetAll()
                .Where(a => a.StepTemplateActionTemplates.Count(st => st.StepTemplate == stepInfo.TemplateId) > 0)
                .ToList();

            foreach (var actionTemplate in actionTemplates)
            {
                var action = this.CreateAction(step, actionTemplate);
                if (step.ActiveActionInFlow == null) // TODO: take most suitable action
                {
                    step.ActiveActionInFlow = action.Id;
                    this.stepService.Update(step, step.Icon);
                }
            }
            throw new NotImplementedException();
        }

        public List<DesireDto> ApplyActionResultDesire(List<DesireDto> desireList, List<ActionResultDesireDto> actionResults)
        {
            throw new NotImplementedException();
        }



        public List<DesireDto> ApplyActionResultDesire(int actionResult, List<DesireDto> desireList)
        {
            throw new NotImplementedException();
        }

        public List<ActionResultDesireDto> GetActiveActionResultDesire(StepDto step)
        {
            var actionResult =
                this.actionResultRepository.GetAll().FirstOrDefault(a => a.Id == step.ActiveActionInFlow.Value);
            var actionRsultDesires = actionResult.ActionResultDesires.ToList();
            return Mapper.Map<List<ActionResultDesireDto>>(actionRsultDesires);
        }


        public ArtifactAdmin.DAL.Models.Action CreateAction(StepDto step, ActionTemplate actionTemplate)
        {
            var action = new ArtifactAdmin.DAL.Models.Action()
                {
                    Duration = 1, // TODO: Звідки це береться?
                    Step = step.Id
                };

            this.actionRepository.Insert(action);
            

            var actionResult = new ActionResult()
                                   {
                                       Action = action.Id,
                                       Gold = (int)actionTemplate.ActionTemplateResult1.GoldModifier,
                                   };

            this.actionResultRepository.Insert(actionResult);

            var desireActionTemplateResult = desireActionTemplateResultRepository.GetAll()
                .Where(datr => datr.ActionTemplateResult == actionTemplate.ActionTemplateResult)
                .ToList();


            foreach (var actionTemplateResult in desireActionTemplateResult)
            {
                actionResultDesireRepository.Insert(new ActionResultDesire()
                                                    {
                                                        ActionResult = actionResult.Id,
                                                        Desire = actionTemplateResult.Desire,
                                                        Modifier = actionTemplateResult.Modifier
                                                    });    
            }
            

            return action;
        }
    }
}