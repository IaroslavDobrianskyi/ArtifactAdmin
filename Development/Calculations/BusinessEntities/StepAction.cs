using System;

namespace Calculations.BusinessEntities
{
    public class StepAction
    {
        public int StepActionId { get; set; }
        public string Description { get; set; }
        public CarrierStep CarrierStepId { get; set; }
        public RequirementMask Requirement { get; set; }
        public StepActionResult Result { get; set; }
    }
}
