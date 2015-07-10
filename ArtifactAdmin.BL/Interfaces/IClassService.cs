// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClassService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IClassService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using ModelsDTO;

    public interface IClassService
    {
        IEnumerable<ClassDto> GetAll();

        ClassDto GetById(int? id);

        ClassDto Create(ClassDto classDto, string fileName);

        ClassDto Update(ClassDto classDto, string fileName);

        void Delete(int? id);
    }
}
