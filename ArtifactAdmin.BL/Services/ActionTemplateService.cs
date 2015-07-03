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
    using System.Linq;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;

    public class ActionTemplateService : IActionTemplateService
    {
        private readonly IRepository<ActionTemplate> actionTemplateRepository;

        public ActionTemplateService(IRepository<ActionTemplate> actionTemplateRepository) 
        {
            this.actionTemplateRepository=actionTemplateRepository;
        }

        public IEnumerable<ActionTemplateDto> GetAll()
        {
            return Mapper.Map<List<ActionTemplateDto>>(this.actionTemplateRepository.GetAll());
        }

        public ActionTemplateDto GetById(int? id)
        {
            return Mapper.Map<ActionTemplateDto>(this.actionTemplateRepository.GetAll().FirstOrDefault(s => s.id == id));
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
            var actionTemplate = this.actionTemplateRepository.GetAll().FirstOrDefault(s => s.id == id);
            this.actionTemplateRepository.Delete(actionTemplate);
        }
    }
}