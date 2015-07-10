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
    
    public partial class Characteristic
    {
        public Characteristic()
        {
            this.ActionCharacteristics = new HashSet<ActionCharacteristic>();
            this.ActionTemplateCharacteristics = new HashSet<ActionTemplateCharacteristic>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Mask { get; set; }
    
        public virtual ICollection<ActionCharacteristic> ActionCharacteristics { get; set; }
        public virtual ICollection<ActionTemplateCharacteristic> ActionTemplateCharacteristics { get; set; }
    }
}
