// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IActionDescriptionService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IActionDescriptionService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Interfaces
{
    using System.Collections.Generic;
    using ModelsDTO;

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
