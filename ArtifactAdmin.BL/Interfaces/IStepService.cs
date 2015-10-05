// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStepService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IStepService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using ArtifactAdmin.BL.ModelsDTO.FlowItems;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IStepService
    {
        StepDto GetById(int? id);

        StepDto Create(StepDto stepDto, string fileName);

        StepDto Update(StepDto stepDto, string fileName);

        void Delete(int? id);
    }
}
