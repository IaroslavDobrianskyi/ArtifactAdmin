﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RaceService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the RaceService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.BL.Utils;
using ArtifactAdmin.DAL.Models;
using AutoMapper;

namespace ArtifactAdmin.BL.Services
{
    public class RaceService : IRaceService
    {
        private readonly IRepository<Race> raceRepository;
        private readonly IRepository<Characteristic> characteristicRepository;
        private readonly IRepository<Predisposition> predispositionRepository;
        private readonly IRepository<Property> propertyRepository;

        public RaceService(IRepository<Race> raceRepository,
            IRepository<Characteristic> characteristicRepository,
            IRepository<Predisposition> predispositionRepository,
            IRepository<Property> propertyRepository) 
        {
            this.raceRepository = raceRepository;
            this.characteristicRepository = characteristicRepository;
            this.predispositionRepository = predispositionRepository;
            this.propertyRepository = propertyRepository;
        }
        
        public IEnumerable<RaceDto> GetAll()
        {
            return Mapper.Map<List<RaceDto>>(this.raceRepository.GetAll());
        }

        public RaceDto GetById(int? id)
        {
            return Mapper.Map<RaceDto>(this.raceRepository.GetAll().FirstOrDefault(s => s.Id == id));
        }

        public RaceDto GetViewById(int? id)
        {
            var raceDto = new RaceDto();
            var viewValueCharacteristic = new ViewValueCharacteristic();
            var viewValuePredisposition = new ViewValueCharacteristic();
            var viewValueProperties = new ViewValueCharacteristic();
            var allCharacteristic = this.characteristicRepository.GetAll().Select(
                        type =>
                        new ViewCharacteristic
                        {
                            Name = type.Name,
                            PositionLength = type.Position.ToString() + "." + type.Length.ToString()
                        }).ToList();
            var allPredisposition = this.predispositionRepository.GetAll().Select(
                        type =>
                        new ViewCharacteristic
                        {
                            Name = type.Name,
                            PositionLength = type.Position.ToString() + "." + type.Length.ToString()
                        }).ToList();
            var allProperty = this.propertyRepository.GetAll().Select(
                        type =>
                        new ViewCharacteristic
                        {
                            Name = type.Name,
                            PositionLength = type.Position.ToString() + "." + type.Length.ToString()
                        }).ToList();
            if (id != null)
            {
                raceDto = Mapper.Map<RaceDto>(this.raceRepository.GetAll()
                                                      .FirstOrDefault(s => s.Id == id));
                viewValueCharacteristic = ViewHelper.GetValueByString(raceDto.Characreristics, allCharacteristic);
                viewValuePredisposition = ViewHelper.GetValueByString(raceDto.Predisposition, allPredisposition);
                viewValueProperties = ViewHelper.GetValueByString(raceDto.Properties, allProperty);
            }
            else
            {
                viewValueCharacteristic = ViewHelper.GetValueByString(null, allCharacteristic);
                viewValuePredisposition = ViewHelper.GetValueByString(null, allPredisposition);
                viewValueProperties = ViewHelper.GetValueByString(null, allProperty);
            }

            raceDto.AllCharacteristics = viewValueCharacteristic.Characteristics;
            raceDto.SelectedCharacteristics = viewValueCharacteristic.SelectedCharacteristics;
            raceDto.SelectedValues = viewValueCharacteristic.SelectedValues;
            raceDto.ValueCharacteristic = 0;
            raceDto.AllPredispositions = viewValuePredisposition.Characteristics;
            raceDto.SelectedPredispositions = viewValuePredisposition.SelectedCharacteristics;
            raceDto.SelectedValuesPredisposition = viewValuePredisposition.SelectedValues;
            raceDto.ValuePredisposition = 0;
            raceDto.AllProperties = viewValueProperties.Characteristics;
            raceDto.SelectedProperties = viewValueProperties.SelectedCharacteristics;
            raceDto.SelectedValuesProperties = viewValueProperties.SelectedValues;
            raceDto.ValueProperty = 0;
            return raceDto;
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
            var race = this.raceRepository.GetAll().FirstOrDefault(s => s.Id == id);
            this.raceRepository.Delete(race);
        }
    }
}