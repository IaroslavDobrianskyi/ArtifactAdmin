// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActionTemplateResultService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IActionTemplateResultService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IActionTemplateResultService
    {
        IEnumerable<ActionTemplateResultDto> GetAll();

        ActionTemplateResultDto GetById(int? id);

        ActionTemplateResultDto Create(ActionTemplateResultDto actionTemplateResultDto);

        ActionTemplateResultDto Update(ActionTemplateResultDto actionTemplateResultDto);

        void Delete(int? id);

    }
}
