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
    public partial class ActionTemplateCharacteristic
    {
        public int Id { get; set; }
        public int ActionTemplate { get; set; }
        public int Characteristics { get; set; }
    
        public virtual ActionTemplate ActionTemplate1 { get; set; }
        public virtual Characteristic Characteristic { get; set; }
    }
}
