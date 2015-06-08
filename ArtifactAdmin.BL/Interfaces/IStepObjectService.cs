// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStepObjectService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IStepObjectService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using ModelsDTO;

    public interface IStepObjectService
    {
        IEnumerable<StepObjectDto> GetAll();

        StepObjectDto GetById(int? id);

        StepObjectDto Create(StepObjectDto stepObjectDto, HttpPostedFileBase icon);

        StepObjectDto Update(StepObjectDto stepObjectDto);

        void Delete(int? id);
    }
}
