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

        StepObjectDto Create(StepObjectDto stepObjectDto, string fileName);

        StepObjectDto Update(StepObjectDto stepObjectDto, string fileName);

        void Delete(int? id);
    }
}
