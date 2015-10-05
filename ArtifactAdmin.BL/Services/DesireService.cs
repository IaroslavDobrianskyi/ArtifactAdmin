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
    using System.Linq;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;
    using Utils;

    public class DesireService : IDesireService
    {
        private readonly IRepository<Desire> desireRepository;
        private readonly IRepository<DesireMapZone> desireMapZoneRepository;
        private readonly IRepository<MapZone> mapZoneRepository;

        public DesireService(IRepository<Desire> desireRepository,
            IRepository<DesireMapZone> desireMapZoneRepository,
            IRepository<MapZone> mapZoneRepository) 
        {
            this.desireRepository = desireRepository;
            this.desireMapZoneRepository = desireMapZoneRepository;
            this.mapZoneRepository = mapZoneRepository;
        }

        public IEnumerable<DesireDto> GetAll()
        {
            return Mapper.Map<List<DesireDto>>(this.desireRepository.GetAll());
        }

        public DesireDto GetById(int? id)
        {
            return Mapper.Map<DesireDto>(this.desireRepository.GetAll().FirstOrDefault(s => s.Id == id)); 
        }

        public DesireDto GetByIdMapZone(int id)
        {
            var desireDto = Mapper.Map<DesireDto>(this.desireRepository.GetAll().FirstOrDefault(s => s.Id == id));
            desireDto.ViewDesireMapZoneDto = new ViewDesireMapZoneDto();
            desireDto.ViewDesireMapZoneDto.ItemId = Convert.ToInt32(id);
            desireDto.ViewDesireMapZoneDto.ItemName = desireDto.Name;
            desireDto.ViewDesireMapZoneDto.ListDesireMapZone = this.desireMapZoneRepository.GetAll()
                                                                   .Where(s => s.Desire == id)
                                                                   .ToList();
            desireDto.ViewDesireMapZoneDto.Modifiers = new List<double>();
            foreach (var mapZone in desireDto.ViewDesireMapZoneDto.ListDesireMapZone)
            {
                desireDto.ViewDesireMapZoneDto.Modifiers.Add(mapZone.Modifier);
            }

            desireDto.ViewDesireMapZoneDto.OneModifier = "0.5";
            return desireDto;
        }

        public DesireDto Create(DesireDto desireDto, string fileName)
        {
            desireDto.Icon = fileName;
            var desire = Mapper.Map<Desire>(desireDto);
            this.desireRepository.InsertWithoutSave(desire);
            CreateDesireMapZoneForDesire(desire);
            this.desireRepository.SaveChanges();
            return Mapper.Map<DesireDto>(desire);
        }

        public void CreateDesireMapZoneForDesire(Desire desire)
        {
            var listMapZones = this.mapZoneRepository.GetAll()
                              .ToList();
            foreach (var mapZone in listMapZones)
            {
                this.desireMapZoneRepository.InsertWithoutSave(new DesireMapZone
                {
                    Desire = desire.Id,
                    MapZone = mapZone.Id,
                    Modifier = 0.5
                });
            }
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
            var desire = this.desireRepository.GetAll().FirstOrDefault(s => s.Id == id);
            this.desireRepository.Delete(desire);
        }

        public void UpdateDesireMapZone(int id, int[] desireMapZoneId, string[] modifiers)
        {
            var desireMapZone = this.desireMapZoneRepository.GetAll()
                                    .Where(s => s.Desire == id)
                                    .ToList();
            var lengthModifiers = modifiers.Length;
            for (var i = 0; i < lengthModifiers; i++)
            {
                foreach (var mapZone in desireMapZone)
                {
                    if (mapZone.Id == desireMapZoneId[i])
                    {
                        modifiers[i] = ViewHelper.ConvertToCurrentSeparator(modifiers[i]);
                        mapZone.Modifier = Convert.ToDouble(modifiers[i]);
                        this.desireMapZoneRepository.UpdateWithoutSave(mapZone);
                    }
                }
            }
            
            this.desireMapZoneRepository.SaveChanges();
        }
    }
}