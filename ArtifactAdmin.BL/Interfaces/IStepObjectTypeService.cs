// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStepObjectTypeService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IStepObjectTypeService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IStepObjectTypeService
    {
        IEnumerable<StepObjectTypeDto> GetAll();

        StepObjectTypeDto GetById(int? id);

        StepObjectTypeDto Create(StepObjectTypeDto stepObjectTypeDto);

        StepObjectTypeDto Update(StepObjectTypeDto stepObjectTypeDto);

        void Delete(int? id);
    }
}
