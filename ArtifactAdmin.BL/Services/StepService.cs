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
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;
    using ModelsDTO.FlowItems;

    public class StepService : IStepService
    {
        private readonly IRepository<Step> stepRepository;

        public StepService(IRepository<Step> stepRepository)
        {
            this.stepRepository = stepRepository;
        }

        public StepDto GetById(int? id)
        {
            return Mapper.Map<StepDto>(this.stepRepository.GetAll()
                                                 .FirstOrDefault(s => s.Id == id));
        }

        public StepDto Create(StepDto stepDto, string fileName)
        {
            stepDto.Icon = fileName;
            var step = Mapper.Map<Step>(stepDto);
            this.stepRepository.Insert(step);
            return Mapper.Map<StepDto>(step);
        }

        public StepDto Update(StepDto stepDto, string fileName)
        {
            stepDto.Icon = fileName;
            var step = Mapper.Map<Step>(stepDto);
            this.stepRepository.Update(step);
            return Mapper.Map<StepDto>(step);
        }

        public void Delete(int? id)
        {
            var step = this.stepRepository.GetAll().FirstOrDefault(s => s.Id == id);
            this.stepRepository.Delete(step);
        }
    }
}