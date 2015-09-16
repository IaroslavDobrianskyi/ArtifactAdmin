// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestTemplateService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the QuestTemplateService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;

    public class QuestTemplateService: IQuestTemplateService
    {
        private readonly IRepository<QuestTemplate> questTemplateRepository;
        private readonly IRepository<StepTemplate> stepTemplateRepository;
        private readonly IRepository<QuestTemplateStepTemplate> questTemplateStepTemplateRepository;
        private readonly IRepository<ActionTemplateResult> actionTemplateResultRepository;

        public QuestTemplateService(IRepository<QuestTemplate> questTemplateRepository,
            IRepository<StepTemplate> stepTemplateRepository,
            IRepository<QuestTemplateStepTemplate> questTemplateStepTemplateRepository,
            IRepository<ActionTemplateResult> actionTemplateResultRepository)
        {
            this.questTemplateRepository = questTemplateRepository;
            this.stepTemplateRepository = stepTemplateRepository;
            this.questTemplateStepTemplateRepository = questTemplateStepTemplateRepository;
            this.actionTemplateResultRepository = actionTemplateResultRepository;
        }

        public IEnumerable<QuestTemplateDto> GetAll()
        {
            return Mapper.Map<List<QuestTemplateDto>>(this.questTemplateRepository.GetAll()
                                                          .Include(s => s.QuestTemplateStepTemplates));
        }

        public QuestTemplateDto GetViewById(int? id)
        {
            var questTemplateDto = new QuestTemplateDto();
            if(id != null)
            {
                questTemplateDto = Mapper.Map<QuestTemplateDto>(this.questTemplateRepository.GetAll().Include(s => s.QuestTemplateStepTemplates)
                                                                    .FirstOrDefault(s => s.Id == id));
            }
            var listSteps = Mapper.Map<List<StepTemplateDto>>(this.stepTemplateRepository.GetAll());
            questTemplateDto.AllSteps = listSteps;
            questTemplateDto.SelectedSteps = new List<StepTemplateDto>();
            if(id != null)
            {
                if (questTemplateDto.QuestTemplateStepTemplates.Any())
                {
                    var orderList = questTemplateDto.QuestTemplateStepTemplates.OrderBy(s => s.StepOrder);

                    foreach (var selectedStep in orderList)
                    {
                        foreach (var step in questTemplateDto.AllSteps)
                        {
                            if (step.Id == selectedStep.StepTemplate)
                            {
                                questTemplateDto.AllSteps.Remove(step);
                                questTemplateDto.SelectedSteps.Add(step);
                                break;
                            }
                        }
                    }
                }
            }
            
            return questTemplateDto;
        }

        public QuestTemplateDto GetById(int? id)
        {
            return Mapper.Map<QuestTemplateDto>(this.questTemplateRepository.GetAll()
                                                    .FirstOrDefault(s => s.Id == id));
        }

        public QuestTemplateDto GetByList(QuestTemplateDto questTemplateDto, string[] steps)
        {
            questTemplateDto.AllSteps = Mapper.Map<List<StepTemplateDto>>(this.stepTemplateRepository.GetAll());
            questTemplateDto.SelectedSteps = new List<StepTemplateDto>();
            foreach (var selectedStep in steps)
            {
                foreach (var step in questTemplateDto.AllSteps)
                {
                    if (step.Id == Convert.ToInt32(selectedStep))
                    {
                        questTemplateDto.AllSteps.Remove(step);
                        questTemplateDto.SelectedSteps.Add(step);
                        break;
                    }
                }
            }

            return questTemplateDto;
        }

        public QuestTemplateDto Create(QuestTemplateDto questTemplateDto, string[] steps)
        {
            var questTemplate = Mapper.Map<QuestTemplate>(questTemplateDto);
            this.questTemplateRepository.InsertWithoutSave(questTemplate);
            if(steps != null)
            {
                CreateQuestTemplateStepTemplate(questTemplate, steps);
            }
            this.questTemplateRepository.SaveChanges();
            return Mapper.Map<QuestTemplateDto>(questTemplate);
        }

        private void CreateQuestTemplateStepTemplate(QuestTemplate questTemplate, string[] steps)
        {
            int stepsLength = steps.Length;
            for (int i = 0; i < stepsLength; i++)
            {
                this.questTemplateStepTemplateRepository.InsertWithoutSave(new QuestTemplateStepTemplate
                                                                           {
                                                                               StepTemplate
                                                                                   =
                                                                                   Convert
                                                                                   .ToInt32
                                                                                   (steps[
                                                                                       i]),
                                                                               QuestTemaplate
                                                                                   =
                                                                                   questTemplate.Id,
                                                                               StepOrder =
                                                                                   i + 1
                                                                           });
            }
        }

        public QuestTemplateDto Update(QuestTemplateDto questTemplateDto, string[] steps)
        {
            var questTemplate = Mapper.Map<QuestTemplate>(questTemplateDto);
            this.questTemplateRepository.UpdateWithoutSave(questTemplate);
            DeleteQuestTemplateStepTemplate(questTemplate);
            if (steps != null)
            {
                CreateQuestTemplateStepTemplate(questTemplate, steps);
            }

            this.questTemplateRepository.SaveChanges();
            return Mapper.Map<QuestTemplateDto>(questTemplate);
        }

        private void DeleteQuestTemplateStepTemplate(QuestTemplate questTemplate)
        {
            var forDelete = this.questTemplateStepTemplateRepository.GetAll()
                                .Where(p => p.QuestTemaplate == questTemplate.Id);
            foreach (var quest in forDelete)
            {
                this.questTemplateStepTemplateRepository.DeleteWithOutSave(quest);
            }
        }

        public void Delete(int? id)
        {
            var questTemplate = this.questTemplateRepository.GetAll()
                                    .FirstOrDefault(s => s.Id ==id);
            this.questTemplateRepository.DeleteWithOutSave(questTemplate);
            DeleteQuestTemplateStepTemplate(questTemplate);
            UpdateActionTemplateResult(questTemplate);
            this.questTemplateRepository.SaveChanges();
        }

        private void UpdateActionTemplateResult(QuestTemplate questTemplate)
        {
            var forUpdate = this.actionTemplateResultRepository.GetAll()
                                .Where(p => p.QuestTemplate == questTemplate.Id);
            foreach(var result in forUpdate)
            {
                result.QuestTemplate = null;
                this.actionTemplateResultRepository.UpdateWithoutSave(result);
            }
            this.actionTemplateResultRepository.SaveChanges();
        }
    }
}