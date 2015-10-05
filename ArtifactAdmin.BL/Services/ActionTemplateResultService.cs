// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplateResultService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplateResultService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;
    using Utils;

    public class ActionTemplateResultService : IActionTemplateResultService
    {
        private readonly IRepository<ActionTemplateResult> actionTemplateResultRepository;
        private readonly IRepository<ActionTemplate> actionTemplateRepository;
        private readonly IRepository<QuestTemplate> questTemplateRepository; 

        public ActionTemplateResultService(IRepository<ActionTemplateResult> actionTemplateResultRepository, IRepository<ActionTemplate> actionTemplateRepository, IRepository<QuestTemplate> questTemplateRepository) 
        {
            this.actionTemplateResultRepository = actionTemplateResultRepository;
            this.actionTemplateRepository = actionTemplateRepository;
            this.questTemplateRepository = questTemplateRepository;
        }

        public IEnumerable<ActionTemplateResultDto> GetAll()
        {
            return Mapper.Map<List<ActionTemplateResultDto>>(this.actionTemplateResultRepository.GetAll());
        }

        public ActionTemplateResultDto GetById(int? id)
        {
            return Mapper.Map<ActionTemplateResultDto>(this.actionTemplateResultRepository.GetAll().FirstOrDefault(s => s.Id == id));
        }

        public ActionTemplateResultDto GetViewById(int? id)
        {
            var actionTemplateResultDto = new ActionTemplateResultDto();
            if (id != null)
            { 
            actionTemplateResultDto = Mapper.Map<ActionTemplateResultDto>(this.actionTemplateResultRepository.GetAll().FirstOrDefault(s => s.Id == id));
                actionTemplateResultDto.Predisposition =
                    ViewHelper.ConvertSeparatorToDot(actionTemplateResultDto.PredispositionResultModifier.ToString());
            actionTemplateResultDto.Experience = ViewHelper.ConvertSeparatorToDot(actionTemplateResultDto.ExperienceModifier.ToString());
            actionTemplateResultDto.Posibility = ViewHelper.ConvertSeparatorToDot(actionTemplateResultDto.ArtifactPosibility.ToString());
            actionTemplateResultDto.Gold = ViewHelper.ConvertSeparatorToDot(actionTemplateResultDto.GoldModifier.ToString());
            actionTemplateResultDto.IsQuestStarter = this.actionTemplateResultRepository.QuestStarter(Convert.ToInt32(id));
            }
            else
            {
                var initialString = ViewHelper.ConvertToCurrentSeparator("0.5");
                var initialValue = Convert.ToDouble(initialString);
                actionTemplateResultDto.Predisposition = "0.5";
                actionTemplateResultDto.Experience = "0.5";
                actionTemplateResultDto.Posibility = "0.5";
                actionTemplateResultDto.Gold = "0.5";
                actionTemplateResultDto.PredispositionResultModifier = initialValue;
                actionTemplateResultDto.ExperienceModifier = initialValue;
                actionTemplateResultDto.ArtifactPosibility = initialValue;
                actionTemplateResultDto.GoldModifier = initialValue; 
                actionTemplateResultDto.IsQuestStarter = 0;
            }

            actionTemplateResultDto.ListQuestTemplates =
               Mapper.Map<List<QuestTemplateDto>>(this.questTemplateRepository.GetAll()
                                                .AsNoTracking().ToList());
            return actionTemplateResultDto;
        }

        public ActionTemplateResultDto Create(ActionTemplateResultDto actionTemplateResultDto)
        {
            var actionTemplateResult = Mapper.Map<ActionTemplateResult>(actionTemplateResultDto);
            this.actionTemplateResultRepository.Insert(actionTemplateResult);
            return Mapper.Map<ActionTemplateResultDto>(actionTemplateResult);
        }

        public ActionTemplateResultDto Update(ActionTemplateResultDto actionTemplateResultDto)
        {
            var actionTemplateResult = Mapper.Map<ActionTemplateResult>(actionTemplateResultDto);
            this.actionTemplateResultRepository.Update(actionTemplateResult);
            return Mapper.Map<ActionTemplateResultDto>(actionTemplateResult);
        }

        public void Delete(int? id)
        {
            var actionTemplateResult = this.actionTemplateResultRepository.GetAll().FirstOrDefault(s => s.Id == id);
            this.actionTemplateResultRepository.Delete(actionTemplateResult);
        }
    }
}