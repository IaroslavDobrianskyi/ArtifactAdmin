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
    using ModelsDTO.FlowItems;

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
            
            Mapper.CreateMap<Step, StepDto>();
            Mapper.CreateMap<StepDto, Step>();

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

            Mapper.CreateMap<ActionTemplateResult, ActionTemplateResultDto>();
            Mapper.CreateMap<ActionTemplateResultDto, ActionTemplateResult>();

            Mapper.CreateMap<DesireActionTemplateResult, DesireActionTemplateResultDto>();
            Mapper.CreateMap<DesireActionTemplateResultDto, DesireActionTemplateResult>();

            Mapper.CreateMap<Desire, DesireDto>();
            Mapper.CreateMap<DesireDto, Desire>();

            Mapper.CreateMap<Race, RaceDto>();
            Mapper.CreateMap<RaceDto, Race>();

            Mapper.CreateMap<Race, ViewRaceDesireDto>();
            Mapper.CreateMap<ViewRaceDesireDto, Race>();

            Mapper.CreateMap<Class, ClassDto>();
            Mapper.CreateMap<ClassDto, Class>();

            Mapper.CreateMap<Characteristic, CharacteristicDto>();
            Mapper.CreateMap<CharacteristicDto, Characteristic>();

            Mapper.CreateMap<Predisposition, PredispositionDto>();
            Mapper.CreateMap<PredispositionDto, Predisposition>();

            Mapper.CreateMap<Property, PropertyDto>();
            Mapper.CreateMap<PropertyDto, Property>();

            Mapper.CreateMap<RaceDesire, RaceDesireDto>();
            Mapper.CreateMap<RaceDesireDto, RaceDesire>();

            Mapper.CreateMap<QuestTemplate, QuestTemplateDto>();
            Mapper.CreateMap<QuestTemplateDto, QuestTemplate>();
        } 
    }
}