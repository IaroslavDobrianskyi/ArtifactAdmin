// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActionTemplateResultService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IActionTemplateResultService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IActionTemplateResultService
    {
        IEnumerable<ActionTemplateResultDto> GetAll();

        ActionTemplateResultDto GetById(int? id);

        ActionTemplateResultDto GetViewById(int? id);

        ActionTemplateResultDto Create(ActionTemplateResultDto actionTemplateResultDto);

        ActionTemplateResultDto Update(ActionTemplateResultDto actionTemplateResultDto);

        void Delete(int? id);
    }
}
