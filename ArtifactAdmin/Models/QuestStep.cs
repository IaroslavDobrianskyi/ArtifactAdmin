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
    
    public partial class QuestStep
    {
        public int Id { get; set; }
        public int Quest { get; set; }
        public int Step { get; set; }
        public int StepOrder { get; set; }
    
        public virtual Quest Quest1 { get; set; }
        public virtual Step Step1 { get; set; }
    }
}
