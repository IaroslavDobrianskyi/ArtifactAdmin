// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStepObjectService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IStepObjectService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IStepObjectService
    {
        IEnumerable<StepObjectDto> GetAll();

        StepObjectDto GetById(int? id);

        StepObjectDto Create(StepObjectDto stepObjectDto, string fileName);

        StepObjectDto Update(StepObjectDto stepObjectDto, string fileName);

        void Delete(int? id);
    }
}
