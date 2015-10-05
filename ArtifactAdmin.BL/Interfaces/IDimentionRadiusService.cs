using System.Collections.Generic;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IDimentionRadiusService
    {
        void Create(DimentionRadiuDto dimentionRadius);

        IEnumerable<DimentionRadiuDto> GetAll();

        DimentionRadiuDto GetById(int? id);
    }
}
