// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActionDescriptionService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IActionDescriptionService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IActionDescriptionService
    {
        IEnumerable<ActionDescriptionDto> GetAll();

        ViewActionDescriptionDto GetViewById(int? id);

        ActionDescriptionDto GetById(int? id);

        ActionDescriptionDto Create(ActionDescriptionDto actionDescriptionDto);

        ActionDescriptionDto Update(ActionDescriptionDto actionDescriptionDto);

        void Delete(int? id);
    }
}
