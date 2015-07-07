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
    public class ActionTemplateResultService: IActionTemplateResultService
    {
        private readonly IRepository<ActionTemplateResult> actionTemplateResultRepository;
        private readonly IRepository<ActionTemplate> actionTemplateRepository;

        public ActionTemplateResultService(IRepository<ActionTemplateResult> actionTemplateResultRepository,
            IRepository<ActionTemplate> actionTemplateRepository) 
        {
            this.actionTemplateResultRepository = actionTemplateResultRepository;
            this.actionTemplateRepository = actionTemplateRepository;
        }
        public IEnumerable<ActionTemplateResultDto> GetAll()
        {
            return Mapper.Map<List<ActionTemplateResultDto>>(this.actionTemplateResultRepository.GetAll());
        }

        public ActionTemplateResultDto GetById(int? id)
        {
            return Mapper.Map<ActionTemplateResultDto>(this.actionTemplateResultRepository.GetAll().FirstOrDefault(s => s.id == id));
        }

        public ActionTemplateResultDto Create(ActionTemplateResultDto actionTemplateResultDto)
        {
            var actionTemplateResult=Mapper.Map<ActionTemplateResult>(actionTemplateResultDto);
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
            var actionTemplateResult = this.actionTemplateResultRepository.GetAll().FirstOrDefault(s => s.id == id);
            this.actionTemplateResultRepository.Delete(actionTemplateResult);
        }
    }
}