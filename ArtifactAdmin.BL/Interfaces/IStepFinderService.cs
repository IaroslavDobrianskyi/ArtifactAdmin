using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.Interfaces
{
    using System.Windows;

    using ArtifactAdmin.BL.ModelsDTO;
    using ArtifactAdmin.BL.ModelsDTO.FlowItems;

    public interface IStepFinderService
    {
        StepCreationInfo GetNewKeyStepInfo(CarrierDesireDto carrierDesire, Point previousStepCoordinates);

        List<StepCreationInfo> GetIntermediateStepCoords(StepDto lastStep, StepCreationInfo newKeyStepCoords);

        List<Point> GetPathPoints();
    }
}