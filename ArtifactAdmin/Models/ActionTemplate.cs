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
    
    public partial class ActionTemplate
    {
        public ActionTemplate()
        {
            this.ActionTemplateCharacteristics = new HashSet<ActionTemplateCharacteristic>();
            this.ActionTemplatePredispositions = new HashSet<ActionTemplatePredisposition>();
            this.ActionTemplateProperties = new HashSet<ActionTemplateProperty>();
            this.StepTemplateActionTemplates = new HashSet<StepTemplateActionTemplate>();
            this.ActionDescriptions = new HashSet<ActionDescription>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public double BlockProbability { get; set; }
        public int ActionTemplateResult { get; set; }
    
        public virtual ActionTemplateResult ActionTemplateResult1 { get; set; }
        public virtual ICollection<ActionTemplateCharacteristic> ActionTemplateCharacteristics { get; set; }
        public virtual ICollection<ActionTemplatePredisposition> ActionTemplatePredispositions { get; set; }
        public virtual ICollection<ActionTemplateProperty> ActionTemplateProperties { get; set; }
        public virtual ICollection<StepTemplateActionTemplate> StepTemplateActionTemplates { get; set; }
        public virtual ICollection<ActionDescription> ActionDescriptions { get; set; }
    }
}
