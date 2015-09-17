 // --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapZoneService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the MapZoneService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;
    using Utils;

    public class MapZoneService : IMapZoneService
    {
        private readonly IRepository<MapZone> mapZoneRepository;
        private readonly IRepository<MapObject> mapObjectRepository;
        private readonly IRepository<MapObjectProbability> mapObjectProbabilityRepository;
        private readonly IRepository<Desire> desireRepository;
        private readonly IRepository<DesireMapZone> desireMapZoneRepository;

        public MapZoneService(IRepository<MapZone> mapZoneRepository,
            IRepository<MapObject> mapObjectRepository,
            IRepository<MapObjectProbability> mapObjectProbabilityRepository,
            IRepository<Desire> desireRepository,
            IRepository<DesireMapZone> desireMapZoneRepository) 
        {
            this.mapZoneRepository = mapZoneRepository;
            this.mapObjectRepository = mapObjectRepository;
            this.mapObjectProbabilityRepository = mapObjectProbabilityRepository;
            this.desireMapZoneRepository = desireMapZoneRepository;
            this.desireRepository = desireRepository;
        }

        public IEnumerable<MapZoneDto> GetAll()
        {
            return Mapper.Map<List<MapZoneDto>>(this.mapZoneRepository.GetAll().Include(s => s.MapObjectProbabilities));
        }

        public MapZoneDto GetById(int? id)
        {
            return Mapper.Map<MapZoneDto>(this.mapZoneRepository.GetAll().FirstOrDefault(s => s.Id == id));
        }

        public MapZoneDto GetByIdDesire(int id)
        {
            var mapZoneDto = Mapper.Map<MapZoneDto>(this.mapZoneRepository.GetAll().FirstOrDefault(s => s.Id == id));
            mapZoneDto.ViewDesireMapZoneDto = new ViewDesireMapZoneDto();
            mapZoneDto.ViewDesireMapZoneDto.ItemId = id;
            mapZoneDto.ViewDesireMapZoneDto.ItemName = mapZoneDto.ZoneName;
            mapZoneDto.ViewDesireMapZoneDto.ListDesireMapZone = this.desireMapZoneRepository.GetAll()
                                                                    .Where(s => s.MapZone == id)
                                                                    .ToList();
            mapZoneDto.ViewDesireMapZoneDto.Modifiers = new List<double>();
            foreach (var desire in mapZoneDto.ViewDesireMapZoneDto.ListDesireMapZone)
            {
                mapZoneDto.ViewDesireMapZoneDto.Modifiers.Add(desire.Modifier);
            }

            mapZoneDto.ViewDesireMapZoneDto.OneModifier = ViewHelper.ConvertToCurrentSeparator("0.5");
            return mapZoneDto;
        } 

        public ViewMapZoneDto GetViewById(int? id)
        {
            var viewMapZoneDto = new ViewMapZoneDto();
            viewMapZoneDto.OneProbability = "0.25";
            var listProbabilityObjects = new List<MapObjectProbabilityDto>();
            if (id != null)
            {
                viewMapZoneDto.MapZone = Mapper.Map<MapZoneDto>(this.mapZoneRepository.GetAll().FirstOrDefault(s => s.Id == id));
                listProbabilityObjects = Mapper.Map<List<MapObjectProbabilityDto>>(this.mapObjectProbabilityRepository.GetAll()
                    .Include(s => s.MapObject1)
                    .Where(p => p.MapZone == id));
            }

            var allObjects = Mapper.Map<List<MapObjectDto>>(this.mapObjectRepository.GetAll());
            viewMapZoneDto.SelectedMapObject = new List<MapObjectProbabilityDto>();
            viewMapZoneDto.Probability = new List<MapObjectProbabilityDto>();
            if (listProbabilityObjects == null)
            {
                viewMapZoneDto.MapObject = allObjects;
            }
            else 
            {
                viewMapZoneDto.MapObject = new List<MapObjectDto>();
                viewMapZoneDto.SelectedMapObject = listProbabilityObjects;
                viewMapZoneDto.Probability = listProbabilityObjects;
                foreach (var obj in allObjects)
                {
                    bool sel = false;
                    foreach (var probability in listProbabilityObjects) 
                    {
                        if (obj.Id == probability.MapObject) 
                        {
                            sel = true;
                            break;
                        }
                    }

                    if (!sel)
                    {
                        viewMapZoneDto.MapObject.Add(obj);
                    }
                }
            }
            
            return viewMapZoneDto;
        }

        public MapZoneDto Create(MapZoneDto mapZoneDto, string[] obj, string[] probability)
        {
            var mapZone = Mapper.Map<MapZone>(mapZoneDto);
            this.mapZoneRepository.InsertWithoutSave(mapZone);
            CreateDesireMapZoneForMap(mapZone);
            if (obj != null) 
            {
                CreateMapObjectProbability(mapZone, obj, probability);
            }

            this.mapZoneRepository.SaveChanges();
            return Mapper.Map<MapZoneDto>(mapZone);
        }

        public void CreateDesireMapZoneForMap(MapZone mapZone)
        {
            var listDesires = this.desireRepository.GetAll().ToList();
            foreach (var desire in listDesires)
            {
                this.desireMapZoneRepository.InsertWithoutSave(new DesireMapZone
                                                               {
                                                                   Desire = desire.Id,
                                                                   MapZone = mapZone.Id,
                                                                   Modifier = 0.5
                                                               });
            }
        }

        public void CreateMapObjectProbability(MapZone mapZone, string[] obj, string[] probability)
        {
            int objLength = obj.Length;
            int objId = 0;
            double objProbability = 0;
            for (int i = 0; i < objLength; i++) 
            {
                objProbability = Convert.ToDouble(probability[i]);
                if (objProbability > 0 & objProbability < 1) 
                {
                    objId = Convert.ToInt32(obj[i]);
                    this.mapObjectProbabilityRepository.InsertWithoutSave(new MapObjectProbability
                    {
                        MapObject = objId,
                        MapZone1 = mapZone,
                        Probability = objProbability
                    });
                }
            }
        }

        public MapZoneDto Update(MapZoneDto mapZoneDto, string[] obj, string[] probability)
        {
            var mapZone = Mapper.Map<MapZone>(mapZoneDto);
            this.mapZoneRepository.UpdateWithoutSave(mapZone);
            DeleteMapObjectProbability(mapZone);
            if (obj != null) 
            {
                CreateMapObjectProbability(mapZone, obj, probability);
            }

            this.mapZoneRepository.SaveChanges();
            return Mapper.Map<MapZoneDto>(mapZone);
        }

        public void DeleteMapObjectProbability(MapZone mapZone) 
        {
            var forDel = this.mapObjectProbabilityRepository.GetAll().Where(p => p.MapZone == mapZone.Id);
            foreach (var obj in forDel) 
            {
                this.mapObjectProbabilityRepository.DeleteWithOutSave(obj);
            }
        }

        public void UpdateDesireMapZone(int id, int[] desireMapZoneId, double[] modifiers)
        {
            var desireMapZone = this.desireMapZoneRepository.GetAll()
                                    .Where(s => s.MapZone == id)
                                    .ToList();
            var lengthModifiers = modifiers.Length;
            for (var i = 0; i < lengthModifiers; i++)
            {
                foreach (var desire in desireMapZone)
                {
                    if (desire.Id == desireMapZoneId[i])
                    {
                        desire.Modifier = modifiers[i];
                        this.desireMapZoneRepository.UpdateWithoutSave(desire);
                    }
                }
            }

            this.desireMapZoneRepository.SaveChanges();
        }

        public void Delete(int? id)
        {
            var mapZone = this.mapZoneRepository.GetAll().FirstOrDefault(s => s.Id == id);
            this.mapZoneRepository.DeleteWithOutSave(mapZone);
            DeleteMapObjectProbability(mapZone);
            this.mapZoneRepository.SaveChanges();
        }
    }
}