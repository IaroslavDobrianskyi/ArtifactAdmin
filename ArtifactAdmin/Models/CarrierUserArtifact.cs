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
    
    public partial class CarrierUserArtifact
    {
        public int id { get; set; }
        public int Carrier { get; set; }
        public int UserArtifact { get; set; }
        public int Addiction { get; set; }
    
        public virtual Carrier Carrier1 { get; set; }
        public virtual UserArtifact UserArtifact1 { get; set; }
    }
}