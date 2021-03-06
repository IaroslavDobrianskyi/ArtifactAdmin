//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArtifactAdmin.DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Action
    {
        public Action()
        {
            this.ActionCharacteristics = new HashSet<ActionCharacteristic>();
            this.ActionPredispositions = new HashSet<ActionPredisposition>();
            this.ActionProperties = new HashSet<ActionProperty>();
            this.ActionResults = new HashSet<ActionResult>();
            this.ActiveActionInFlows = new HashSet<ActiveActionInFlow>();
        }
    
        public int Id { get; set; }
        public int Step { get; set; }
        public string Text { get; set; }
        public string PredispositionResult { get; set; }
        public Nullable<double> ExperienceModifier { get; set; }
        public Nullable<long> Duration { get; set; }
        public Nullable<int> ActionChangeCost { get; set; }
        public Nullable<int> ActionImprovementCost { get; set; }
        public string Icon { get; set; }
    
        public virtual Step Step1 { get; set; }
        public virtual ICollection<ActionCharacteristic> ActionCharacteristics { get; set; }
        public virtual ICollection<ActionPredisposition> ActionPredispositions { get; set; }
        public virtual ICollection<ActionProperty> ActionProperties { get; set; }
        public virtual ICollection<ActionResult> ActionResults { get; set; }
        public virtual ICollection<ActiveActionInFlow> ActiveActionInFlows { get; set; }
    }
}
