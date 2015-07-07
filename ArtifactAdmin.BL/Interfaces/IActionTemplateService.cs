// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActionTemplateService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IActionTemplateService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IActionTemplateService
    {
        IEnumerable<ActionTemplateDto> GetAll();

        ViewActionTemplateDto GetViewById(int? id);
        
        ActionTemplateDto GetById(int? id);

        ActionTemplateDto Create(ActionTemplateDto actionTemplateDto);

        ActionTemplateDto Update(ActionTemplateDto actionTEmplateDto);

        void Delete(int? id);
    }
}
