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
    
    public partial class Carrier
    {
        public Carrier()
        {
            this.CarrierDesires = new HashSet<CarrierDesire>();
            this.CarrierUserArtifacts = new HashSet<CarrierUserArtifact>();
        }
    
        public int id { get; set; }
        public int Race { get; set; }
        public int ExperienceLevel { get; set; }
        public int ExperiencePoints { get; set; }
        public long Properties { get; set; }
        public long Predisposition { get; set; }
        public long Characteristics { get; set; }
        public long DefaultPredisposition { get; set; }
    
        public virtual Race Race1 { get; set; }
        public virtual ICollection<CarrierDesire> CarrierDesires { get; set; }
        public virtual ICollection<CarrierUserArtifact> CarrierUserArtifacts { get; set; }
    }
}
