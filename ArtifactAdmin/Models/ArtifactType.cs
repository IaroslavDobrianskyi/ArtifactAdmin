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
    
    public partial class ArtifactType
    {
        public ArtifactType()
        {
            this.Artifacts = new HashSet<Artifact>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Descrioption { get; set; }
    
        public virtual ICollection<Artifact> Artifacts { get; set; }
    }
}
