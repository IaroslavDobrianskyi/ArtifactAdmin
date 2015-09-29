// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InjectionConfig.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the InjectionConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL
{
    using System;
    using DAL.Models;
    using Interfaces;
    using LightInject;
    using Services;

    public static class InjectionConfig
    {
        public static ServiceContainer RegisterAllDependencies()
        {
            var container = new ServiceContainer();
            container.Register<IArtifactTypeService, ArtifactTypeService>(new PerScopeLifetime());
            container.Register<IBonusService, BonusService>(new PerScopeLifetime());
            container.Register<IConstellationService, ConstellationService>(new PerScopeLifetime());
            container.Register<IStepObjectService, StepObjectService>(new PerScopeLifetime());
            container.Register<IStepObjectTypeService, StepObjectTypeService>(new PerScopeLifetime());
            container.Register<ITalentService, TalentService>(new PerScopeLifetime());
            container.Register<IStepTemplateService, StepTemplateService>(new PerScopeLifetime());
            container.Register<IMapObjectService, MapObjectService>(new PerScopeLifetime());
            container.Register<IMapInfoService, MapInfoService>(new PerScopeLifetime());
            container.Register<IDimentionRadiusService, DimentionRadiusService>(new PerScopeLifetime());
            container.Register<IMapInfoDimensionService, MapInfoDimensionService>(new PerScopeLifetime());
            container.Register<IZoneCoordinatesService, ZoneCoordinatesService>(new PerScopeLifetime());
            container.Register<IMapZoneService, MapZoneService>(new PerScopeLifetime());
            container.Register<IActionTemplateService, ActionTemplateService>(new PerScopeLifetime());
            container.Register<IActionDescriptionService, ActionDescriptionService>(new PerScopeLifetime());
            container.Register<IStepActionTemplateService, StepActionTemplateService>(new PerScopeLifetime());
            container.Register<IActionTemplateResultService, ActionTemplateResultService>(new PerScopeLifetime());
            container.Register<IDesireService, DesireService>(new PerScopeLifetime());
            container.Register<IRaceService, RaceService>(new PerScopeLifetime());
            container.Register<IClassService, ClassService>(new PerScopeLifetime());
            container.Register<ICharacteristicService, CharacteristicService>(new PerScopeLifetime());
            container.Register<IPredispositionService, PredispositionService>(new PerScopeLifetime());
            container.Register<IPropertyService, PropertyService>(new PerScopeLifetime());
            container.Register<IRaceDesireService, RaceDesireService>(new PerScopeLifetime());
            container.Register<IQuestTemplateService, QuestTemplateService>(new PerScopeLifetime());
                
            container.Register((serviceFactory) => new artEntities(), new PerScopeLifetime());
            container.Register(typeof(IRepository<>), typeof(Repository<>));
            
            return container;
        }
    }
}