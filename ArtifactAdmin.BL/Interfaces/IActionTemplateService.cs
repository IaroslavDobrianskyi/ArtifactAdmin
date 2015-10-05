// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActionTemplateService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IActionTemplateService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IActionTemplateService
    {
        IEnumerable<ActionTemplateDto> GetAll();

        ViewActionTemplateDto GetViewById(int? id);
        
        ActionTemplateDto GetById(int? id);

        ActionTemplateDto Create(ActionTemplateDto actionTemplateDto);

        ActionTemplateDto Update(ActionTemplateDto actionTEmplateDto);

        void Delete(int? id);

        ViewDesireActionResultDto GetViewDesireResult(int? id, string name);

        void UpdateDesireActionResult(int id, int[] desires, string[] modifiers);
        ViewDesireActionResultDto GetViewDesireResultByList(int id, string name,int[] desires, string[] modifiers);
    }
}
