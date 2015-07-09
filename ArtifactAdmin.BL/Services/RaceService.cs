// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RaceService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the RaceService type.
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

    public class RaceService: IRaceService
    {
        private readonly IRepository<Race> raceRepository;

        public RaceService(IRepository<Race> raceRepository) 
        {
            this.raceRepository = raceRepository;
        }
        
        public IEnumerable<RaceDto> GetAll()
        {
            return Mapper.Map<List<RaceDto>>(this.raceRepository.GetAll());
        }

        public RaceDto GetById(int? id)
        {
            return Mapper.Map<RaceDto>(this.raceRepository.GetAll().FirstOrDefault(s => s.id == id));
        }

        public RaceDto Create(RaceDto raceDto, string fileName)
        {
            raceDto.Icon = fileName;
            var race = Mapper.Map<Race>(raceDto);
            this.raceRepository.Insert(race);
            return Mapper.Map<RaceDto>(race);
        }

        public RaceDto Update(RaceDto raceDto, string fileName)
        {
            raceDto.Icon = fileName;
            var race = Mapper.Map<Race>(raceDto);
            this.raceRepository.Update(race);
            return Mapper.Map<RaceDto>(race);
        }

        public void Delete(int? id)
        {
            var race = this.raceRepository.GetAll().FirstOrDefault(s => s.id == id);
            this.raceRepository.Delete(race);

        }
    }
}