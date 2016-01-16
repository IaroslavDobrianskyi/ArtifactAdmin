using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.Interfaces
{
    using System.Drawing;

    using ArtifactAdmin.BL.ModelsDTO;
    using ArtifactAdmin.BL.ModelsDTO.FlowItems;

    public interface IStepFinderService
    {
        Point GetNewKeyStepCoords(CarrierDesireDto carrierDesire, Point stepCoordinates);

        List<Point> GetIntermediateStepCoords(StepDto lastStep, Point newKeyStepCoords);
    }
}