//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;

namespace ArtifactAdmin.DAL.Models
{
    public partial class StepObject
    {
        public StepObject()
        {
            this.StepObjectStepTemplates = new HashSet<StepObjectStepTemplate>();
        }
    
        public int Id { get; set; }
        public int StepObjectType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    
        public virtual StepObjectType StepObjectType1 { get; set; }
        public virtual ICollection<StepObjectStepTemplate> StepObjectStepTemplates { get; set; }
    }
}
