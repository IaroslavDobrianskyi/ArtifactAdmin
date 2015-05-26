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
        private readonly IRepository<StepObject> stepObjectRepository; 

        public StepTemplateService(IRepository<StepTemplate> stepTemplateRepository,
             IRepository<StepObjectType> stepObjectTypeRepository, 
            IRepository<StepObjectStepTemplate> stepObjectStepTemplateRepository, 
            IRepository<StepObject> stepObjectRepository)
        {
            this.stepTemplateRepository = stepTemplateRepository;
            this.stepObjectTypeRepository = stepObjectTypeRepository;
            this.stepObjectStepTemplateRepository = stepObjectStepTemplateRepository;
            this.stepObjectRepository = stepObjectRepository;
        }

        public IEnumerable<StepTemplateDto> GetAll()
        {
            return Mapper.Map<List<StepTemplateDto>>(this.stepTemplateRepository.GetAll().Include(s => s.StepObjectStepTemplates));
        }

        public ViewStepTemplateDto GetViewById(int? id)
        {
            var viewStepTemplateDto = new ViewStepTemplateDto();
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
            return Mapper.Map<StepTemplateDto>(this.stepTemplateRepository.GetAll()
                                                   .FirstOrDefault(s => s.id == id));
        }

        public StepTemplateDto Create(StepTemplateDto stepTemplateDto, string[] obj)
        {
            var stepTemplate = Mapper.Map<StepTemplate>(stepTemplateDto);
            this.stepTemplateRepository.InsertDependent(stepTemplate, obj);
            return Mapper.Map<StepTemplateDto>(stepTemplate);
        }

        public StepTemplateDto Update(StepTemplateDto stepTewmplateDto, string[] obj)
        {
            var stepTemplate = Mapper.Map<StepTemplate>(stepTewmplateDto);
            this.stepTemplateRepository.UpdateDependent(stepTemplate, obj);
            return Mapper.Map<StepTemplateDto>(stepTemplate);
        }

        public void Delete(int? id)
        {
            var stepTemplate = this.stepTemplateRepository.GetAll()
                                   .FirstOrDefault(s => s.id == id);
            this.stepTemplateRepository.Delete(stepTemplate);
        }
    }
}