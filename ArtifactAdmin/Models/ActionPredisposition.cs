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
    
    public partial class ActionPredisposition
    {
        public int Id { get; set; }
        public int Predisposition { get; set; }
        public int Action { get; set; }
    
        public virtual Action Action1 { get; set; }
        public virtual Predisposition Predisposition1 { get; set; }
    }
}
