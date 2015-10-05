// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepObjectTypeService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines theStepObjectTypeService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.DAL.Models;
using AutoMapper;

namespace ArtifactAdmin.BL.Services
{
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