// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperConfiguration.cs" company="Thomas Cook Group">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the AutoMapperConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL
{
    using System;
    using AutoMapper;
    using DAL.Models;
    using ModelsDTO;

    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Bonu, BonusDto>();
            Mapper.CreateMap<BonusDto, Bonu>();

            Mapper.CreateMap<ArtifactType, ArtifactTypeDto>();
            Mapper.CreateMap<ArtifactTypeDto, ArtifactType>();

            Mapper.CreateMap<Constellation, ConstellationDto>();
            Mapper.CreateMap<ConstellationDto, Constellation>();

            Mapper.CreateMap<StepObject, StepObjectDto>();
            Mapper.CreateMap<StepObjectDto, StepObject>();

            Mapper.CreateMap<StepObjectType, StepObjectTypeDto>();
            Mapper.CreateMap<StepObjectTypeDto, StepObjectType>();

            Mapper.CreateMap<StepTemplate, StepTemplateDto>();
            Mapper.CreateMap<StepTemplateDto, StepTemplate>();

            Mapper.CreateMap<StepObjectStepTemplate, StepObjectStepTemplateDto>();
            Mapper.CreateMap<StepObjectStepTemplateDto, StepObjectStepTemplate>();

            Mapper.CreateMap<Talent, TalentDto>();
            Mapper.CreateMap<TalentDto, Talent>();

            Mapper.CreateMap<MapObject, MapObjectDto>();
            Mapper.CreateMap<MapObjectDto, MapObject>();

            Mapper.CreateMap<MapZone, MapZoneDto>();
            Mapper.CreateMap<MapZoneDto, MapZone>();

            Mapper.CreateMap<MapObjectProbability, MapObjectProbabilityDto>();
            Mapper.CreateMap<MapObjectProbabilityDto, MapObjectProbability>();

            Mapper.CreateMap<ActionTemplate, ActionTemplateDto>();
            Mapper.CreateMap<ActionTemplateDto, ActionTemplate>();

            Mapper.CreateMap<ActionDescription, ActionDescriptionDto>();
            Mapper.CreateMap<ActionDescriptionDto, ActionDescription>();

            Mapper.CreateMap<StepTemplateActionTemplate, StepTemplateActionTemplateDto>();
            Mapper.CreateMap<StepTemplateActionTemplateDto, StepTemplateActionTemplate>();
        } 
    }
}