// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActionService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IActionService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using ModelsDTO;
    using ModelsDTO.FlowItems;

    public interface IActionService
    {
        // Вихідний параметр список нових обєктів типу ActionResult
        List<int> RetrieveListOfActionResults(StepDto currentStepDto, StepDto lastStepDto);

        /// <summary>
        /// Останні значення бажань
        /// </summary>
        /// <param name="actionResults">Вхідний параметр список нових обєктів типу ActionResult</param>
        /// <param name="desireList">значення бажань на які треба накласти результати дій</param>
        /// <returns></returns>
        List<DesireDto> ApplyActionResultDesire(List<int> actionResults, List<DesireDto> desireList);

        /// <summary>
        /// Згенерувати результат дій
        /// </summary>
        /// <param name="step"></param>
        /// <returns>ActionResult</returns>
        int GenerateActionResult(StepDto step);

        List<DesireDto> ApplyActionResultDesire(int actionResult, List<DesireDto> desireList);
    }
}
