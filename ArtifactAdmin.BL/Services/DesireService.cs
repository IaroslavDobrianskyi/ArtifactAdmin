// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DesireService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the DesireService type.
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

    public class DesireService : IDesireService
    {
        private readonly IRepository<Desire> desireRepository;

        public DesireService(IRepository<Desire> desireRepository) 
        {
            this.desireRepository = desireRepository;
        }
        public IEnumerable<DesireDto> GetAll()
        {
            return Mapper.Map<List<DesireDto>>(this.desireRepository.GetAll());
        }

        public DesireDto GetById(int? id)
        {
            return Mapper.Map<DesireDto>(this.desireRepository.GetAll().FirstOrDefault(s => s.id == id));
        }

        public DesireDto Create(DesireDto desireDto, string fileName)
        {
            desireDto.Icon = fileName;
            var desire = Mapper.Map<Desire>(desireDto);
            this.desireRepository.Insert(desire);
            return Mapper.Map<DesireDto>(desire);
        }

        public DesireDto Update(DesireDto desireDto, string fileName)
        {
            desireDto.Icon = fileName;
            var desire = Mapper.Map<Desire>(desireDto);
            this.desireRepository.Update(desire);
            return Mapper.Map<DesireDto>(desire);
        }

        public void Delete(int? id)
        {
            var desire = this.desireRepository.GetAll().FirstOrDefault(s => s.id == id);
            this.desireRepository.Delete(desire);
        }
    }
}