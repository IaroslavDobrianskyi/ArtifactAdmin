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
    
    public partial class CharrierCharacteristic
    {
        public int id { get; set; }
        public int Strength { get; set; }
        public int Armor { get; set; }
        public int Agility { get; set; }
        public int Accuracy { get; set; }
        public int Knowledge { get; set; }
        public int Intellect { get; set; }
        public int HitPoints { get; set; }
        public int Carrier { get; set; }
    
        public virtual Carrier Carrier1 { get; set; }
    }
}
