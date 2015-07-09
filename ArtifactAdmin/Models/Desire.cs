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
    
    public partial class Desire
    {
        public Desire()
        {
            this.ActionResultDesires = new HashSet<ActionResultDesire>();
            this.CarrierDesires = new HashSet<CarrierDesire>();
            this.DesireActionTemplateResults = new HashSet<DesireActionTemplateResult>();
            this.DesireMapZones = new HashSet<DesireMapZone>();
            this.RaceDesires = new HashSet<RaceDesire>();
            this.Steps = new HashSet<Step>();
            this.StepTemplates = new HashSet<StepTemplate>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    
        public virtual ICollection<ActionResultDesire> ActionResultDesires { get; set; }
        public virtual ICollection<CarrierDesire> CarrierDesires { get; set; }
        public virtual ICollection<DesireActionTemplateResult> DesireActionTemplateResults { get; set; }
        public virtual ICollection<DesireMapZone> DesireMapZones { get; set; }
        public virtual ICollection<RaceDesire> RaceDesires { get; set; }
        public virtual ICollection<Step> Steps { get; set; }
        public virtual ICollection<StepTemplate> StepTemplates { get; set; }
    }
}