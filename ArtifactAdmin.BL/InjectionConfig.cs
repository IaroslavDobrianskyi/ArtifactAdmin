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
            container.Register<IArtifactTypeService, ArtifactTypeService>(new PerContainerLifetime());
            container.Register<IBonusService, BonusService>(new PerScopeLifetime());
            container.Register<IConstellationService, ConstellationService>(new PerScopeLifetime());
            container.Register<IStepObjectService, StepObjectService>(new PerScopeLifetime());
            container.Register<IStepObjectTypeService, StepObjectTypeService>(new PerScopeLifetime());
            container.Register<ITalentService, TalentService>(new PerScopeLifetime());
            container.Register<IStepTemplateService,StepTemplateService>(new PerScopeLifetime());

            container.Register((serviceFactory) => new artEntities(), new PerScopeLifetime());
            container.Register(typeof(IRepository<>), typeof(Repository<>));
            
            return container;
        }
    }
}