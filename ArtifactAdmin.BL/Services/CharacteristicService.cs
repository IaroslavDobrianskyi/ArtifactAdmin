// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CharacteristicService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the CharacteristicService type.
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

    public class CharacteristicService : ICharacteristicService
    {
        private readonly IRepository<Characteristic> characteristicRepository;

        public CharacteristicService(IRepository<Characteristic> characteristicRepository)
        {
            this.characteristicRepository = characteristicRepository;
        }

        public IEnumerable<CharacteristicDto> GetAll()
        {
            return Mapper.Map<List<CharacteristicDto>>(this.characteristicRepository.GetAll());
        }

        public CharacteristicDto GetById(int? id)
        {
            return Mapper.Map<CharacteristicDto>(this.characteristicRepository.GetAll()
                                                     .FirstOrDefault(s => s.Id == id)); 
        }

        public CharacteristicDto GetByPosition(int position)
        {
            return Mapper.Map<CharacteristicDto>(this.characteristicRepository.GetAll()
                                                     .FirstOrDefault(s => s.Position == position));
        }

        public CharacteristicDto Create(CharacteristicDto characteristicDto)
        {
            var characteristic = Mapper.Map<Characteristic>(characteristicDto);
            this.characteristicRepository.Insert(characteristic);
            return Mapper.Map<CharacteristicDto>(characteristic);
        }

        public CharacteristicDto Update(CharacteristicDto characteristicDto)
        {
            var characteristic = Mapper.Map<Characteristic>(characteristicDto);
            this.characteristicRepository.Update(characteristic);
            return Mapper.Map<CharacteristicDto>(characteristic);
        }

        public void Delete(int id)
        {
            var characteristic = this.characteristicRepository.GetAll()
                                     .FirstOrDefault(s => s.Id == id);
            this.characteristicRepository.Delete(characteristic);
        }
    }
}