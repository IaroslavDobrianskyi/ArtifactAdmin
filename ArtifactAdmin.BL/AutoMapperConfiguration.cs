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
        } 
    }
}