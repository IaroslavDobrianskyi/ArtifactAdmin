// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstellationService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ConstellationService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;

    public class ConstellationService : IConstellationService
    {
        private readonly IRepository<Constellation> constellationRepository;

        public ConstellationService(IRepository<Constellation> constellationRepository)
        {
            this.constellationRepository = constellationRepository;
        }

        public IEnumerable<ConstellationDto> GetAll()
        {
            return Mapper.Map<List<ConstellationDto>>(this.constellationRepository.GetAll());
        }

        public ConstellationDto GetById(int? id)
        {
            return Mapper.Map<ConstellationDto>(this.constellationRepository.GetAll()
                                                    .FirstOrDefault(s => s.Id == id));
        }

        public ConstellationDto Create(ConstellationDto constellationDto, string fileName)
        {
            constellationDto.Icon = fileName;
            var constellation = Mapper.Map<Constellation>(constellationDto);
            this.constellationRepository.Insert(constellation);
            return Mapper.Map<ConstellationDto>(constellation);
        }

        public ConstellationDto Update(ConstellationDto constellationDto, string fileName)
        {
            constellationDto.Icon = fileName;
            var constellation = Mapper.Map<Constellation>(constellationDto);
            this.constellationRepository.Update(constellation);
            return Mapper.Map<ConstellationDto>(constellation);
        }

        public void Delete(int? id)
        {
            var constellation = this.constellationRepository.GetAll()
                                    .FirstOrDefault(s => s.Id == id);
            this.constellationRepository.Delete(constellation);
        }
    }
}