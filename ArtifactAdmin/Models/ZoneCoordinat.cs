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
    
    public partial class ZoneCoordinat
    {
        public int Id { get; set; }
        public int MapZone { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    
        public virtual MapZone MapZone1 { get; set; }
    }
}
