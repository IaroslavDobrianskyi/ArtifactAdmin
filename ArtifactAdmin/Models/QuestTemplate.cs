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
    using System.Collections.Generic;

    public partial class QuestTemplate
    {
        public QuestTemplate()
        {
            this.ActionTemplateResults = new HashSet<ActionTemplateResult>();
            this.QuestTemplateStepTemplates = new HashSet<QuestTemplateStepTemplate>();
            this.Quests = new HashSet<Quest>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<ActionTemplateResult> ActionTemplateResults { get; set; }
        public virtual ICollection<QuestTemplateStepTemplate> QuestTemplateStepTemplates { get; set; }
        public virtual ICollection<Quest> Quests { get; set; }
    }
}
