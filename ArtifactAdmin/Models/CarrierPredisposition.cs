//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArtifactAdmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarrierPredisposition
    {
        public int id { get; set; }
        public double Kindness { get; set; }
        public double Temperance { get; set; }
        public double Bravery { get; set; }
        public double Eloquence { get; set; }
        public double Cunning { get; set; }
        public double Inventiveness { get; set; }
        public double Observation { get; set; }
        public int Carrier { get; set; }
    
        public virtual Carrier Carrier1 { get; set; }
    }
}
