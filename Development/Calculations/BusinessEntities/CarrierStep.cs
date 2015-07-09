using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculations.BusinessEntities;

namespace Calculations.BusinessEntities
{
    public class CarrierStep
    {
        public int CarrierStepId { get; set; }
        public string Description { get; set; }
        public StepAction CurrentAction { get; set; } // Reference to current action
        public List<StepAction> Actions { get; set; } //List of available actions on current step
        public CarrierAttribute EffectiveAttribute { get; set; } //Attribute that affects step longetivity
    }
}
