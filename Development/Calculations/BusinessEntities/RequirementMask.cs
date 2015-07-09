using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculations.BusinessEntities
{
    public class RequirementMask
    {
        private double[] predispositionMask; // [0,4 ; 0,7 ; 0,8 ; 0 ; 1 ; 0,9 ; 0,5]

        public RequirementMask(double[] mask)
        {
            foreach(var predispositionValue in mask)
            {
                if(predispositionValue < 0 || predispositionValue > 1)
                {
                    throw new Exception("Predisposition is out of bounds");
                }
            }
            this.predispositionMask = mask;
        }
        
        public RequirementMask(double kindness, double temperance, double bravery, double eloquence, double cunning, double inventiveness, double observation)
        {
            //TODO Check limits
            this.predispositionMask = new double[7]{kindness, temperance, bravery, eloquence, cunning, inventiveness, observation};
        }

        public double[] PredispositionMask { get; set; }
    }
}
