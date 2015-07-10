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
    
    public partial class ActionTemplateResult
    {
        public ActionTemplateResult()
        {
            this.ActionTemplates = new HashSet<ActionTemplate>();
            this.DesireActionTemplateResults = new HashSet<DesireActionTemplateResult>();
        }
    
        public int Id { get; set; }
        public double PredispositionResultModifier { get; set; }
        public double ExperienceModifier { get; set; }
        public double ArtifactPosibility { get; set; }
        public double GoldModifier { get; set; }
    
        public virtual ICollection<ActionTemplate> ActionTemplates { get; set; }
        public virtual ICollection<DesireActionTemplateResult> DesireActionTemplateResults { get; set; }
    }
}
