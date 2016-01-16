using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.Services
{
    using System.Drawing;

    using ArtifactAdmin.BL.Interfaces;
    using ArtifactAdmin.BL.ModelsDTO;
    using ArtifactAdmin.BL.ModelsDTO.FlowItems;

    public class StepFinderService : IStepFinderService
    {
        public Point GetNewKeyStepCoords(CarrierDesireDto carrierDesire, Point stepCoordinates)
        {
            throw new NotImplementedException();
        }

        public List<Point> GetIntermediateStepCoords(StepDto lastStep, Point newKeyStepCoords)
        {
            throw new NotImplementedException();
        }
    }
}