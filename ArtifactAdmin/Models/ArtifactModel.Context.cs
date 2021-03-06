﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class artEntities : DbContext
    {
        public artEntities()
            : base("name=artEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bonu> Bonus { get; set; }
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<ActionCharacteristic> ActionCharacteristics { get; set; }
        public virtual DbSet<ActionDescription> ActionDescriptions { get; set; }
        public virtual DbSet<ActionPredisposition> ActionPredispositions { get; set; }
        public virtual DbSet<ActionProperty> ActionProperties { get; set; }
        public virtual DbSet<ActionResult> ActionResults { get; set; }
        public virtual DbSet<ActionResultDesire> ActionResultDesires { get; set; }
        public virtual DbSet<ActionTemplate> ActionTemplates { get; set; }
        public virtual DbSet<ActionTemplateCharacteristic> ActionTemplateCharacteristics { get; set; }
        public virtual DbSet<ActionTemplatePredisposition> ActionTemplatePredispositions { get; set; }
        public virtual DbSet<ActionTemplateProperty> ActionTemplateProperties { get; set; }
        public virtual DbSet<ActionTemplateResult> ActionTemplateResults { get; set; }
        public virtual DbSet<ActiveActionInFlow> ActiveActionInFlows { get; set; }
        public virtual DbSet<Artifact> Artifacts { get; set; }
        public virtual DbSet<ArtifactBonu> ArtifactBonus { get; set; }
        public virtual DbSet<ArtifactType> ArtifactTypes { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<CarrierUserArtifact> CarrierUserArtifacts { get; set; }
        public virtual DbSet<Characteristic> Characteristics { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Constellation> Constellations { get; set; }
        public virtual DbSet<ConstellationBonu> ConstellationBonus { get; set; }
        public virtual DbSet<Desire> Desires { get; set; }
        public virtual DbSet<DesireActionTemplateResult> DesireActionTemplateResults { get; set; }
        public virtual DbSet<DesireMapZone> DesireMapZones { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<MapObject> MapObjects { get; set; }
        public virtual DbSet<MapObjectProbability> MapObjectProbabilities { get; set; }
        public virtual DbSet<MapZone> MapZones { get; set; }
        public virtual DbSet<Predisposition> Predispositions { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<RaceDesire> RaceDesires { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<Step> Steps { get; set; }
        public virtual DbSet<StepObject> StepObjects { get; set; }
        public virtual DbSet<StepObjectStepTemplate> StepObjectStepTemplates { get; set; }
        public virtual DbSet<StepObjectType> StepObjectTypes { get; set; }
        public virtual DbSet<StepTemplate> StepTemplates { get; set; }
        public virtual DbSet<StepTemplateActionTemplate> StepTemplateActionTemplates { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Talent> Talents { get; set; }
        public virtual DbSet<UserArtifact> UserArtifacts { get; set; }
        public virtual DbSet<UserArtifactClass> UserArtifactClasses { get; set; }
        public virtual DbSet<UserArtifactTalent> UserArtifactTalents { get; set; }
        public virtual DbSet<ZoneCoordinat> ZoneCoordinats { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Quest> Quests { get; set; }
        public virtual DbSet<QuestStep> QuestSteps { get; set; }
        public virtual DbSet<QuestTemplate> QuestTemplates { get; set; }
        public virtual DbSet<QuestTemplateStepTemplate> QuestTemplateStepTemplates { get; set; }
        public virtual DbSet<ActionTemplateActionDescription> ActionTemplateActionDescriptions { get; set; }
        public virtual DbSet<MapInfo> MapInfoes { get; set; }
        public virtual DbSet<MapInfoDimension> MapInfoDimensions { get; set; }
        public virtual DbSet<MiddlePoint> MiddlePoints { get; set; }
        public virtual DbSet<MiddlePointNeighbor> MiddlePointNeighbors { get; set; }
        public virtual DbSet<DimentionRadiu> DimentionRadius { get; set; }
        public virtual DbSet<PathFinderConfig> PathFinderConfigs { get; set; }
        public virtual DbSet<CarrierDesire> CarrierDesires { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<StepTemplateMapZone> StepTemplateMapZones { get; set; }
    
        public virtual ObjectResult<Nullable<int>> QuestStarter(Nullable<int> idActionResult)
        {
            var idActionResultParameter = idActionResult.HasValue ?
                new ObjectParameter("idActionResult", idActionResult) :
                new ObjectParameter("idActionResult", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("QuestStarter", idActionResultParameter);
        }
    }
}
