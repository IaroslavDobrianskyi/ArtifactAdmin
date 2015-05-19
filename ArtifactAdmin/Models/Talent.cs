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
    
    public partial class Talent
    {
        public Talent()
        {
            this.UserArtifactTalents = new HashSet<UserArtifactTalent>();
        }
    
        public int id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int MaxLevel { get; set; }
        public double Modifier { get; set; }
        public double BaseValue { get; set; }
        public double BaseModifier { get; set; }
        public string Icon { get; set; }
    
        public virtual ICollection<UserArtifactTalent> UserArtifactTalents { get; set; }
    }
}
