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
    
    public partial class ActionResultDesire
    {
        public int id { get; set; }
        public int ActionResult { get; set; }
        public int Desire { get; set; }
        public double Modifier { get; set; }
    
        public virtual ActionResult ActionResult1 { get; set; }
        public virtual Desire Desire1 { get; set; }
    }
}
