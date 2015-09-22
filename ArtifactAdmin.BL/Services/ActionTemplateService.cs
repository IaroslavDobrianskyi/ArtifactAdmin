// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionTemplateService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionTemplateService type.
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

    public class ActionTemplateService : IActionTemplateService
    {
        private readonly IRepository<ActionTemplate> actionTemplateRepository;
        private readonly IRepository<ActionTemplateResult> actionTemplateResultRepository;

        public ActionTemplateService(IRepository<ActionTemplate> actionTemplateRepository,
            IRepository<ActionTemplateResult> actionTemplateResultRepository) 
        {
            this.actionTemplateRepository = actionTemplateRepository;
            this.actionTemplateResultRepository = actionTemplateResultRepository;
        }

        public IEnumerable<ActionTemplateDto> GetAll()
        {
            return Mapper.Map<List<ActionTemplateDto>>(this.actionTemplateRepository.GetAll().Include(s => s.ActionTemplateResult1));
        }

        public ViewActionTemplateDto GetViewById(int? id) 
        {
            var viewActionTemplateDto = new ViewActionTemplateDto();
            viewActionTemplateDto.OneProbability = "0.25";
            viewActionTemplateDto.ActionTemplateResults = Mapper.Map<List<ActionTemplateResultDto>>(this.actionTemplateResultRepository.GetAll());
            if (id != null) 
            {
                viewActionTemplateDto.ActionTemplateDto = Mapper.Map<ActionTemplateDto>(this.actionTemplateRepository.GetAll().FirstOrDefault(s => s.Id == id));
                if (viewActionTemplateDto.ActionTemplateDto != null)
                {
                    viewActionTemplateDto.OneProbability = viewActionTemplateDto.ActionTemplateDto.BlockProbability.ToString();
                }
            }

            return viewActionTemplateDto;
        }

        public ActionTemplateDto GetById(int? id)
        {
            return Mapper.Map<ActionTemplateDto>(this.actionTemplateRepository.GetAll().FirstOrDefault(s => s.Id == id));
        }

        public ActionTemplateDto Create(ActionTemplateDto actionTemplateDto)
        {
            var actionTemplate = Mapper.Map<ActionTemplate>(actionTemplateDto);
            this.actionTemplateRepository.Insert(actionTemplate);
            return Mapper.Map<ActionTemplateDto>(actionTemplate);
        }

        public ActionTemplateDto Update(ActionTemplateDto actionTemplateDto)
        {
            var actionTemplate = Mapper.Map<ActionTemplate>(actionTemplateDto);
            this.actionTemplateRepository.Update(actionTemplate);
            return Mapper.Map<ActionTemplateDto>(actionTemplate);
        }

        public void Delete(int? id)
        {
            var actionTemplate = this.actionTemplateRepository.GetAll().FirstOrDefault(s => s.Id == id);
            this.actionTemplateRepository.Delete(actionTemplate);
        }
    }
}