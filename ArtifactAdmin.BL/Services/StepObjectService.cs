// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepObjectService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepObjectServicetype.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;

    public class StepObjectService : IStepObjectService
    {
        private readonly IRepository<StepObject> stepObjectRepository;

        public StepObjectService(IRepository<StepObject> stepObjectRepository)
        {
            this.stepObjectRepository = stepObjectRepository;
        }

        public IEnumerable<StepObjectDto> GetAll()
        {
            return Mapper.Map<List<StepObjectDto>>(this.stepObjectRepository.GetAll().Include(s => s.StepObjectType1));
        }

        public StepObjectDto GetById(int? id)
        {
            return Mapper.Map<StepObjectDto>(this.stepObjectRepository.GetAll()
                                                 .FirstOrDefault(s => s.Id == id));
        }

        public StepObjectDto Create(StepObjectDto stepObjectDto, string fileName)
        {
            stepObjectDto.Icon = fileName;
            var stepObject = Mapper.Map<StepObject>(stepObjectDto);
            this.stepObjectRepository.Insert(stepObject);
            return Mapper.Map<StepObjectDto>(stepObject);
        }

        public StepObjectDto Update(StepObjectDto stepObjectDto, string fileName)
        {
            stepObjectDto.Icon = fileName;
            var stepObject = Mapper.Map<StepObject>(stepObjectDto);
            this.stepObjectRepository.Update(stepObject);
            return Mapper.Map<StepObjectDto>(stepObject);
        }

        public void Delete(int? id)
        {
            var stepObject = this.stepObjectRepository.GetAll().FirstOrDefault(s => s.Id == id);
            this.stepObjectRepository.Delete(stepObject);
        }
    }
}