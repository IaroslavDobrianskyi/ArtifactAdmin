namespace ArtifactAdmin.BL.Interfaces
{
    using System.Collections.Generic;
    using ModelsDTO;

    public interface IDimentionRadiusService
    {
        void Create(DimentionRadiuDto dimentionRadius);

        IEnumerable<DimentionRadiuDto> GetAll();

        DimentionRadiuDto GetById(int? id);
    }
}
