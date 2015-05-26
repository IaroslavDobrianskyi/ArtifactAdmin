// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConstellationService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IConstellationService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using ModelsDTO;

    public interface IConstellationService
    {
        IEnumerable<ConstellationDto> GetAll();

        ConstellationDto GetById(int? id);
        
        ConstellationDto Create(ConstellationDto constellationDto, HttpPostedFileBase icon);

        void SaveIcon(ConstellationDto constellationDto, HttpPostedFileBase icon);
        
        ConstellationDto Update(ConstellationDto constellationDto);

        void Delete(int? id);
    }
}
