// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClassService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IClassService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IClassService
    {
        IEnumerable<ClassDto> GetAll();

        ClassDto GetById(int? id);

        ClassDto Create(ClassDto classDto, string fileName);

        ClassDto Update(ClassDto classDto, string fileName);

        void Delete(int? id);
    }
}
