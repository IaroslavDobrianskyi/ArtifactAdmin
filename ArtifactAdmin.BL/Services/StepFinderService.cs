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
        public StepCreationInfo GetNewKeyStepInfo(CarrierDesireDto carrierDesire, Point previousStepCoordinates)
        {
            throw new NotImplementedException();
        }

        public List<StepCreationInfo> GetIntermediateStepCoords(StepDto lastStep, StepCreationInfo newKeyStepCoords)
        {
            throw new NotImplementedException();
        }
    }
}