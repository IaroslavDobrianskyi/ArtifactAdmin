// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the PropertyService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.DAL.Models;
using AutoMapper;

namespace ArtifactAdmin.BL.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IRepository<Property> propertyRepository;

        public PropertyService(IRepository<Property> propertyRepository)
        {
            this.propertyRepository = propertyRepository;
        }

        public IEnumerable<PropertyDto> GetAll()
        {
            return Mapper.Map<List<PropertyDto>>(this.propertyRepository.GetAll());
        }

        public PropertyDto GetById(int? id)
        {
            return Mapper.Map<PropertyDto>(this.propertyRepository.GetAll()
                                                     .FirstOrDefault(s => s.Id == id));
        }

        public PropertyDto GetByPosition(int position)
        {
            return Mapper.Map<PropertyDto>(this.propertyRepository.GetAllNoTracking()
                                                      .FirstOrDefault(s => s.Position == position));
        }

        public PropertyDto GetMaxByPosition(int position)
        {
            return Mapper.Map<PropertyDto>(this.propertyRepository.GetAllNoTracking()
                                                     .Where(s => s.Position < position)
                                                     .OrderByDescending(s => s.Position)
                                                     .FirstOrDefault());
        }

        public PropertyDto GetMinByPosition(int position)
        {
            return Mapper.Map<PropertyDto>(this.propertyRepository.GetAllNoTracking()
                                                     .Where(s => s.Position > position)
                                                     .OrderBy(s => s.Position)
                                                     .FirstOrDefault());
        }

        public PropertyDto Create(PropertyDto propertyDto)
        {
            var property = Mapper.Map<Property>(propertyDto);
            this.propertyRepository.Insert(property);
            return Mapper.Map<PropertyDto>(property);
        }

        public PropertyDto Update(PropertyDto propertyDto)
        {
            var property = Mapper.Map<Property>(propertyDto);
            this.propertyRepository.Update(property);
            return Mapper.Map<PropertyDto>(property);
        }

        public void Delete(int id)
        {
            var property = this.propertyRepository.GetAll()
                               .FirstOrDefault(s => s.Id == id);
            this.propertyRepository.Delete(property);
        }
    }
}