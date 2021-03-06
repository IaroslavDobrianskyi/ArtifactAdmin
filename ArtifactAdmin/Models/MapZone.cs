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
    
    public partial class MapZone
    {
        public MapZone()
        {
            this.ActionDescriptions = new HashSet<ActionDescription>();
            this.DesireMapZones = new HashSet<DesireMapZone>();
            this.MapObjectProbabilities = new HashSet<MapObjectProbability>();
            this.ZoneCoordinats = new HashSet<ZoneCoordinat>();
            this.StepTemplateMapZones = new HashSet<StepTemplateMapZone>();
        }
    
        public int Id { get; set; }
        public string ZoneName { get; set; }
        public string Color { get; set; }
    
        public virtual ICollection<ActionDescription> ActionDescriptions { get; set; }
        public virtual ICollection<DesireMapZone> DesireMapZones { get; set; }
        public virtual ICollection<MapObjectProbability> MapObjectProbabilities { get; set; }
        public virtual ICollection<ZoneCoordinat> ZoneCoordinats { get; set; }
        public virtual ICollection<StepTemplateMapZone> StepTemplateMapZones { get; set; }
    }
}
