// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertyService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the IPropertyService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Interfaces
{
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IPropertyService
    {
        IEnumerable<PropertyDto> GetAll();
        
        PropertyDto GetById(int? id);
        
        PropertyDto GetByPosition(int position);
        
        PropertyDto GetMaxByPosition(int position);

        PropertyDto GetMinByPosition(int position);

        PropertyDto Create(PropertyDto propertyDto);

        PropertyDto Update(PropertyDto propertyDto);

        void Delete(int id);
    }
}
