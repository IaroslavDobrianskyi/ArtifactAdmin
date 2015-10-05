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
    public partial class Race
    {
        public Race()
        {
            this.ActionDescriptions = new HashSet<ActionDescription>();
            this.Carriers = new HashSet<Carrier>();
            this.RaceDesires = new HashSet<RaceDesire>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public string Characreristics { get; set; }
        public string CharacteristicsLevelModifier { get; set; }
        public string Predisposition { get; set; }
        public string Properties { get; set; }
        public string Icon { get; set; }
    
        public virtual ICollection<ActionDescription> ActionDescriptions { get; set; }
        public virtual ICollection<Carrier> Carriers { get; set; }
        public virtual ICollection<RaceDesire> RaceDesires { get; set; }
    }
}
