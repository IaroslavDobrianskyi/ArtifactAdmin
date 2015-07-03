// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStepActionTemplateService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IStepActionTemplateService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IStepActionTemplateService
    {
        IEnumerable<StepTemplateDto> GetAll();

        ViewStepActionTemplateDto GetViewById(int? id);

        StepTemplateDto GetById(int? id);

        StepTemplateDto Create(StepTemplateDto stepTemplateDto, string[] obj);

        StepTemplateDto Update(StepTemplateDto stepTewmplateDto, string[] obj);

        void Delete(int? id);
    }
}
