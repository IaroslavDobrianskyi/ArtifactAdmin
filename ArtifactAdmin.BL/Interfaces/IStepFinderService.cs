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
        StepCreationInfo GetNewKeyStepInfo(CarrierDesireDto carrierDesire, Point previousStepCoordinates);

        List<StepCreationInfo> GetIntermediateStepCoords(StepDto lastStep, StepCreationInfo newKeyStepCoords);
    }
}