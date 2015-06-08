// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITalentService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ITalentService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using ModelsDTO;
    
    public interface ITalentService
    {
        IEnumerable<TalentDto> GetAll();

        TalentDto GetById(int? id);

        TalentDto Create(TalentDto talentDto, HttpPostedFileBase icon);

        TalentDto Update(TalentDto talentDto);

        void Delete(int? id);
    }
}
