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
    
    public partial class UserArtifactTalent
    {
        public int Id { get; set; }
        public int UserArtifact { get; set; }
        public int UserTalent { get; set; }
        public int TalentLevel { get; set; }
    
        public virtual Talent Talent { get; set; }
        public virtual UserArtifact UserArtifact1 { get; set; }
    }
}
