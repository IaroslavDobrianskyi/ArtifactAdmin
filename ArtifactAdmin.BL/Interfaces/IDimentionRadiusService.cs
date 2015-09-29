using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtifactAdmin.BL.ModelsDTO;

namespace ArtifactAdmin.BL.Interfaces
{
    public interface IDimentionRadiusService
    {
        void Create(ModelsDTO.DimentionRadiuDto dimentionRadius);

        IEnumerable<DimentionRadiuDto> GetAll();

        DimentionRadiuDto GetById(int? id);
    }
}
