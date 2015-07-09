// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDesireService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IDesireService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using ModelsDTO;

    public interface IDesireService
    {
        IEnumerable<DesireDto> GetAll();

        DesireDto GetById(int? id);

        DesireDto Create(DesireDto desireDto, string fileName);

        DesireDto Update(DesireDto desireDto, string fileName);

        void Delete(int? id);
    }
}
