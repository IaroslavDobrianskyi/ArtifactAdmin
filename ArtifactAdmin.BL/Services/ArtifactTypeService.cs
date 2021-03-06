﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArtifactTypeService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ArtifactTypeService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;

    public class ArtifactTypeService : IArtifactTypeService
    {
        private readonly IRepository<ArtifactType> artifactTypeRepository;

        public ArtifactTypeService(IRepository<ArtifactType> artifactTypeRepository)
        {
            this.artifactTypeRepository = artifactTypeRepository;
        }

        public IEnumerable<ArtifactTypeDto> GetAll()
        {
            var artifactType = this.artifactTypeRepository.GetAll();
            return Mapper.Map<List<ArtifactTypeDto>>(this.artifactTypeRepository.GetAll());
        }

        public ArtifactTypeDto GetById(int? id)
        {
            var artifactType = this.artifactTypeRepository.GetAll()
                                   .FirstOrDefault(s => s.Id == id);
            return Mapper.Map<ArtifactTypeDto>(this.artifactTypeRepository.GetAll().FirstOrDefault(s => s.Id == id));
        }

        public ArtifactTypeDto Create(ArtifactTypeDto artifactTypeDto, string fileName)
        {
            artifactTypeDto.Icon = fileName;
            var artifactType = Mapper.Map<ArtifactType>(artifactTypeDto);
            this.artifactTypeRepository.Insert(artifactType);
            return Mapper.Map<ArtifactTypeDto>(artifactType);
        }

        public ArtifactTypeDto Update(ArtifactTypeDto artifactTypeDto, string fileName)
        {
            artifactTypeDto.Icon = fileName;
            var artifactType = Mapper.Map<ArtifactType>(artifactTypeDto);
            this.artifactTypeRepository.Update(artifactType);
            return Mapper.Map<ArtifactTypeDto>(artifactType);
        }

        public void Delete(int? id)
        {
            var artifactType = this.artifactTypeRepository.GetAll()
                                   .FirstOrDefault(s => s.Id == id);
            this.artifactTypeRepository.Delete(artifactType);
        }
    }
}