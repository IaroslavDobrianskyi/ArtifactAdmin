// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepTemplateService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepTemplateService interface.
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

    public class StepTemplateService : IStepTemplateService
    {
        private readonly IRepository<StepTemplate> stepTemplateRepository;
        private readonly IRepository<StepObjectType> stepObjectTypeRepository;
        private readonly IRepository<StepObjectStepTemplate> stepObjectStepTemplateRepository;
        private readonly IRepository<StepTemplateActionTemplate> stepTemplateActionTemplateRepository;
        private readonly IRepository<StepObject> stepObjectRepository;
        private readonly IRepository<Desire> desireRepository;

        public StepTemplateService(IRepository<StepTemplate> stepTemplateRepository,
             IRepository<StepObjectType> stepObjectTypeRepository, 
            IRepository<StepObjectStepTemplate> stepObjectStepTemplateRepository, 
            IRepository<StepTemplateActionTemplate> stepTemplateActionTemplateRepository,
            IRepository<StepObject> stepObjectRepository,
            IRepository<Desire> desireRepository)
        {
            this.stepTemplateRepository = stepTemplateRepository;
            this.stepObjectTypeRepository = stepObjectTypeRepository;
            this.stepObjectStepTemplateRepository = stepObjectStepTemplateRepository;
            this.stepTemplateActionTemplateRepository = stepTemplateActionTemplateRepository;
            this.stepObjectRepository = stepObjectRepository;
            this.desireRepository = desireRepository;
        }

        public IEnumerable<StepTemplateDto> GetAll()
        {
            return Mapper.Map<List<StepTemplateDto>>(this.stepTemplateRepository.GetAll().Include(s => s.StepObjectStepTemplates).
                Include(s=>s.Desire1));
        }

        public ViewStepTemplateDto GetViewById(int? id)
        {
            var viewStepTemplateDto = new ViewStepTemplateDto();
            viewStepTemplateDto.DesireDto = Mapper.Map<List<DesireDto>>(this.desireRepository.GetAll());
            viewStepTemplateDto.StepObjectType =
                Mapper.Map<List<StepObjectTypeDto>>(this.stepObjectTypeRepository.GetAll());
             viewStepTemplateDto.StepObjectType.Add(null);
             string[] selectedObj = null;
            if (id != null)
            {
                viewStepTemplateDto.StepTemplate = Mapper.Map<StepTemplateDto>(this.stepTemplateRepository.GetAll()
                                                                                   .FirstOrDefault(s => s.id == id));
            
                var listObjects = Mapper.Map<List<StepObjectStepTemplateDto>>(this.stepObjectStepTemplateRepository.GetAll()
                                                                        .Include(s => s.StepObject1)
                                                                        .Where(p => p.StepTemplate == id));
            var countListObjects = listObjects.Count();
            
            if (countListObjects > 0)
            {
                selectedObj = new string[countListObjects];
                var i = 0;
                foreach (var type in listObjects)
                {
                    selectedObj[i] = type.StepObject1.Id.ToString() + "." + type.StepObject1.StepObjectType.ToString();
                    i++;
                }
            }
            }

            var allObjects = Mapper.Map<List<StepObjectDto>>(this.stepObjectRepository.GetAll());
            var viewObjects = allObjects.Select(type => new ViewStepObjectDto { StepObjectDto = type, IdObjType = type.Id.ToString() + "." + type.StepObjectType.ToString() })
                                       .ToList();
            viewStepTemplateDto.SelectedStepObject = new List<ViewStepObjectDto>();
            if (selectedObj == null)
            {
                viewStepTemplateDto.StepObject = viewObjects;
            }
            else
            {
                viewStepTemplateDto.StepObject = new List<ViewStepObjectDto>();
                foreach (var type in viewObjects)
                {
                    bool sel = false;
                    for (int i = 0; i < selectedObj.Length; i++)
                    {
                        if (type.IdObjType == selectedObj[i])
                        {
                            sel = true;
                            break;
                        }
                    }

                    if (sel)
                    {
                        viewStepTemplateDto.SelectedStepObject.Add(type);
                    }
                    else
                    {
                        viewStepTemplateDto.StepObject.Add(type);
                    }
                }
            }

            return viewStepTemplateDto;
        }

        public StepTemplateDto GetById(int? id)
        {
            return Mapper.Map<StepTemplateDto>(this.stepTemplateRepository.GetAll().Include(s=>s.Desire1)
                                                   .FirstOrDefault(s => s.id == id));
        }

        public StepTemplateDto Create(StepTemplateDto stepTemplateDto, string[] stepObj)
        {
            var stepTemplate = Mapper.Map<StepTemplate>(stepTemplateDto);
            this.stepTemplateRepository.InsertWithoutSave(stepTemplate);
            if (stepObj != null)
            {
                CreateStepObjectStepTemplate(stepTemplate, stepObj);
            }

            this.stepTemplateRepository.SaveChanges();
            return Mapper.Map<StepTemplateDto>(stepTemplate);
        }

        public StepTemplateDto Update(StepTemplateDto stepTewmplateDto, string[] stepObj)
        {
            var stepTemplate = Mapper.Map<StepTemplate>(stepTewmplateDto);
            this.stepTemplateRepository.UpdateWithoutSave(stepTemplate);
            DeleteStepObjectTemplate(stepTemplate);
            if (stepObj != null)
            {
                CreateStepObjectStepTemplate(stepTemplate, stepObj);
            }

            this.stepTemplateRepository.SaveChanges();
            return Mapper.Map<StepTemplateDto>(stepTemplate);
        }

        public void CreateStepObjectStepTemplate(StepTemplate stepTemplate, string[] stepObj)
        {
            int stepObjLen = stepObj.Length;
            int fidStepObj = 0;
            for (int i = 0; i < stepObjLen; i++)
            {
                fidStepObj = Convert.ToInt32(stepObj[i].Substring(0, stepObj[i].IndexOf('.')));
                this.stepObjectStepTemplateRepository.InsertWithoutSave(new StepObjectStepTemplate
                {
                    StepObject = fidStepObj,
                    StepTemplate1 = stepTemplate
                });
            }
        }

        public void DeleteFKStepTemplate(StepTemplate stepTemplate) 
        {
            var forDelAction = this.stepTemplateActionTemplateRepository.GetAll().Where(p => p.StepTemplate == stepTemplate.id);
            foreach (var action in forDelAction)
            {
                this.stepTemplateActionTemplateRepository.DeleteWithOutSave(action);
            }

            var forDelObj = this.stepObjectStepTemplateRepository.GetAll().Where(p => p.StepTemplate == stepTemplate.id);
            foreach (var step in forDelObj)
            {
                this.stepObjectStepTemplateRepository.DeleteWithOutSave(step);
            }
        }

        public void DeleteStepObjectTemplate(StepTemplate stepTemplate) 
        {
            var forDelObj = this.stepObjectStepTemplateRepository.GetAll().Where(p => p.StepTemplate == stepTemplate.id);
            foreach (var step in forDelObj)
            {
                this.stepObjectStepTemplateRepository.DeleteWithOutSave(step);
            }
        }
        public void Delete(int? id)
        {
            var stepTemplate = this.stepTemplateRepository.GetAll()
                                   .FirstOrDefault(s => s.id == id);
            this.stepTemplateRepository.DeleteWithOutSave(stepTemplate);
            DeleteFKStepTemplate(stepTemplate);
            this.stepTemplateRepository.SaveChanges();
        }
    }
}