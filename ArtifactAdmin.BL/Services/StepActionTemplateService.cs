// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepActionTemplateService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepActionTemplateService interface.
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

    public class StepActionTemplateService : IStepActionTemplateService
    {
        private readonly IRepository<StepTemplate> stepTemplateRepository;
        private readonly IRepository<ActionTemplate> actionTemplateRepository;
        private readonly IRepository<StepTemplateActionTemplate> stepTemplateActionTemplateRepository;
        private readonly IRepository<StepObjectStepTemplate> stepObjectStepTemplateRepository;

        public StepActionTemplateService(IRepository<StepTemplate> stepTemplateRepository,
            IRepository<ActionTemplate> actionTemplateRepository,
            IRepository<StepTemplateActionTemplate> stepTemplateActionTemplateRepository,
            IRepository<StepObjectStepTemplate> stepObjectStepTemplateRepository) 
        {
            this.stepTemplateRepository = stepTemplateRepository;
            this.actionTemplateRepository = actionTemplateRepository;
            this.stepTemplateActionTemplateRepository = stepTemplateActionTemplateRepository;
            this.stepObjectStepTemplateRepository = stepObjectStepTemplateRepository;
        }

        public IEnumerable<StepTemplateDto> GetAll()
        {
            return Mapper.Map<List<StepTemplateDto>>(this.stepTemplateRepository.GetAll().Include(s => s.StepTemplateActionTemplates));
        }

        public ViewStepActionTemplateDto GetViewById(int? id)
        {
            var viewStepActionTemplateDto = new ViewStepActionTemplateDto();
            var listActions = new List<StepTemplateActionTemplateDto>();
            if (id != null) 
            {
                viewStepActionTemplateDto.StepTemplateDto = Mapper.Map<StepTemplateDto>(this.stepTemplateRepository.GetAll()
                    .FirstOrDefault(s => s.Id == id));
                listActions = Mapper.Map<List<StepTemplateActionTemplateDto>>(this.stepTemplateActionTemplateRepository.GetAll()
                    .Include(s => s.ActionTemplate1).Where(p => p.StepTemplate == id));
            }

            var allActions = Mapper.Map<List<ActionTemplateDto>>(this.actionTemplateRepository.GetAll());
            viewStepActionTemplateDto.SelectedActionTemplate = new List<ActionTemplateDto>();
            viewStepActionTemplateDto.ActionTemplate = new List<ActionTemplateDto>();
            if (listActions == null)
            {
                viewStepActionTemplateDto.ActionTemplate = allActions;
            }
            else
            {
                foreach (var action in allActions) 
                {
                    bool sel = false;
                    foreach (var selAction in listActions) 
                    {
                        if (action.Id == selAction.ActionTemplate) 
                        {
                            sel = true;
                            break;
                        }
                    }

                    if (sel)
                    {
                        viewStepActionTemplateDto.SelectedActionTemplate.Add(action);
                    }
                    else 
                    {
                        viewStepActionTemplateDto.ActionTemplate.Add(action);
                    }
                }
            }

            return viewStepActionTemplateDto;
        }

        public StepTemplateDto GetById(int? id)
        {
            return Mapper.Map<StepTemplateDto>(this.stepTemplateRepository.GetAll()
                                                   .FirstOrDefault(s => s.Id == id));
        }

        public StepTemplateDto Create(StepTemplateDto stepTemplateDto, string[] obj)
        {
            var stepTemplate = Mapper.Map<StepTemplate>(stepTemplateDto);
            this.stepTemplateRepository.InsertWithoutSave(stepTemplate);
            if (obj != null) 
            {
                CreateStepActionTemplate(stepTemplate, obj);
            }

            this.stepTemplateRepository.SaveChanges();
            return Mapper.Map<StepTemplateDto>(stepTemplate);
        }

        public void CreateStepActionTemplate(StepTemplate stepTemplate, string[] obj) 
        {
            int objLen = obj.Length;
            int fidAction = 0;
            for (int i = 0; i < objLen; i++) 
            {
                fidAction = Convert.ToInt32(obj[i]);
                this.stepTemplateActionTemplateRepository.InsertWithoutSave(new StepTemplateActionTemplate
                {
                    ActionTemplate = fidAction,
                    StepTemplate1 = stepTemplate
                });
            }
        }

        public void DeleteFKStepTemplate(StepTemplate stepTemplate) 
        {
            var forDelAction = this.stepTemplateActionTemplateRepository.GetAll().Where(p => p.StepTemplate == stepTemplate.Id);
            foreach (var action in forDelAction) 
            {
                this.stepTemplateActionTemplateRepository.DeleteWithOutSave(action);
            }

            var forDelObj = this.stepObjectStepTemplateRepository.GetAll().Where(p => p.StepTemplate == stepTemplate.Id);
            foreach (var step in forDelObj)
            {
                this.stepObjectStepTemplateRepository.DeleteWithOutSave(step);
            }
        }

        public void DeleteStepActionTemplate(StepTemplate stepTemplate) 
        {
            var forDelAction = this.stepTemplateActionTemplateRepository.GetAll().Where(p => p.StepTemplate == stepTemplate.Id);
            foreach (var action in forDelAction)
            {
                this.stepTemplateActionTemplateRepository.DeleteWithOutSave(action);
            }
        }

        public StepTemplateDto Update(StepTemplateDto stepTewmplateDto, string[] obj)
        {
            var stepTemplate = Mapper.Map<StepTemplate>(stepTewmplateDto);
            this.stepTemplateRepository.UpdateWithoutSave(stepTemplate);
            DeleteStepActionTemplate(stepTemplate);
            if (obj != null)
            {
                CreateStepActionTemplate(stepTemplate, obj);
            }

            this.stepTemplateRepository.SaveChanges();
            return Mapper.Map<StepTemplateDto>(stepTemplate);
        }

        public void Delete(int? id)
        {
            var stepTemplate = this.stepTemplateRepository.GetAll()
                                  .FirstOrDefault(s => s.Id == id);
            this.stepTemplateRepository.DeleteWithOutSave(stepTemplate);
            DeleteFKStepTemplate(stepTemplate);
            this.stepTemplateRepository.SaveChanges();
        }
    }
}