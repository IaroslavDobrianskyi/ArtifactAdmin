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
                                                    .FirstOrDefault(s => s.id == id));
        }

        public ConstellationDto Create(ConstellationDto constellationDto, HttpPostedFileBase icon)
        {
            var fileName = Path.GetFileName(icon.FileName);
            fileName = Guid.NewGuid().ToString() + '_' + fileName;
            string pathToIcon = App_Start.ImagePath.ImPath;
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(pathToIcon + "Constellations"));
            var path = Path.Combine(HttpContext.Current.Server.MapPath(pathToIcon + "Constellations"), fileName);
            icon.SaveAs(path);
            constellationDto.Icon = fileName;
            var constellation = Mapper.Map<Constellation>(constellationDto);
            this.constellationRepository.Insert(constellation);
            return Mapper.Map<ConstellationDto>(constellation);
        }

        public ConstellationDto Update(ConstellationDto constellationDto)
        {
            var constellation = Mapper.Map<Constellation>(constellationDto);
            this.constellationRepository.Update(constellation);
            return Mapper.Map<ConstellationDto>(constellation);
        }

        public void Delete(int? id)
        {
            var constellation = this.constellationRepository.GetAll()
                                    .FirstOrDefault(s => s.id == id);
            string fileName = constellation.Icon;
            string pathToIcon = App_Start.ImagePath.ImPath;
            var path = Path.Combine(HttpContext.Current.Server.MapPath(pathToIcon + "Constellations"), fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
               file.Delete(); 
            }

            this.constellationRepository.Delete(constellation);
        }
    }
}