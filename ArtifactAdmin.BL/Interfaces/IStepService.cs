// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStepService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IStepService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Interfaces
{
    using System.Drawing;

    using ModelsDTO.FlowItems;

    public interface IStepService
    {
        StepDto GetById(int? id);

        StepDto Create(StepDto stepDto, string fileName);

        StepDto Update(StepDto stepDto, string fileName);

        StepDto RetrieveLastStepFromDb(int carrierId );

        StepDto RetrieveCurrentStepFromDb(int carrierId );

        StepDto GenerateStep(Point point);

        void Delete(int? id);

        /// <summary>
        /// Get the next step for the current step.
        /// </summary>
        /// <param name="currentStep">Current step.</param>
        /// <returns>Next step.</returns>
        StepDto GetNextStep(StepDto currentStep);
    }
}
