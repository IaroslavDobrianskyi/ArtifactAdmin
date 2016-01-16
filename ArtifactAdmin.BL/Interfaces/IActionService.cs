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
        List<ActionResultDesireDto> RetrieveListOfActionResultDesires(List<StepDto> stepsList);

        /// <summary>
        /// Останні значення бажань
        /// </summary>
        /// <param name="desireList">значення бажань на які треба накласти результати дій</param>
        /// <param name="actionResults">Вхідний параметр список нових обєктів типу ActionResult</param>
        /// <returns></returns>
        List<CarrierDesireDto> ApplyActionResultDesire(List<CarrierDesireDto> desireList, List<ActionResultDesireDto> actionResults);

        /// <summary>
        /// Згенерувати результат дій
        /// </summary>
        /// <param name="step"></param>
        /// <returns>ActionResult</returns>
        int GenerateActionResult(StepDto step);

        List<DesireDto> ApplyActionResultDesire(int actionResult, List<DesireDto> desireList);
    }
}
