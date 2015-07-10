// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepObjectTypeService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines theStepObjectTypeService type.
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

    public class StepObjectTypeService : IStepObjectTypeService
    {
        private readonly IRepository<StepObjectType> stepObjectTypeRoRepository;

        public StepObjectTypeService(IRepository<StepObjectType> stepObjectTypeRepository)
        {
            this.stepObjectTypeRoRepository = stepObjectTypeRepository;
        }

        public IEnumerable<StepObjectTypeDto> GetAll()
        {
            return Mapper.Map<List<StepObjectTypeDto>>(this.stepObjectTypeRoRepository.GetAll());
        }

public StepObjectTypeDto GetById(int? id)
{
    return Mapper.Map<StepObjectTypeDto>(this.stepObjectTypeRoRepository.GetAll()
                                             .FirstOrDefault(s => s.Id == id));
}

public StepObjectTypeDto Create(StepObjectTypeDto stepObjectTypeDto)
{
    var stepObjectType = Mapper.Map<StepObjectType>(stepObjectTypeDto);
    this.stepObjectTypeRoRepository.Insert(stepObjectType);
    return Mapper.Map<StepObjectTypeDto>(stepObjectType);
}

public StepObjectTypeDto Update(StepObjectTypeDto stepObjectTypeDto)
{
    var stepObjectType = Mapper.Map<StepObjectType>(stepObjectTypeDto);
    this.stepObjectTypeRoRepository.Update(stepObjectType);
    return Mapper.Map<StepObjectTypeDto>(stepObjectType);
}

public void Delete(int? id)
{
    var stepObjectType = this.stepObjectTypeRoRepository.GetAll()
                             .FirstOrDefault(s => s.Id == id);
    this.stepObjectTypeRoRepository.Delete(stepObjectType);
}
}
}