// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ClassService type.
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
    public class ClassService : IClassService
    {
        private readonly IRepository<Class> classRepository;

        public ClassService(IRepository<Class> classRepository) 
        {
            this.classRepository = classRepository;
        }

        public IEnumerable<ClassDto> GetAll()
        {
            return Mapper.Map<List<ClassDto>>(this.classRepository.GetAll());
        }

        public ClassDto GetById(int? id)
        {
            return Mapper.Map<ClassDto>(this.classRepository.GetAll().FirstOrDefault(s => s.Id == id));
        }

        public ClassDto Create(ClassDto classDto, string fileName)
        {
            classDto.Icon = fileName;
            var clas = Mapper.Map<Class>(classDto);
            this.classRepository.Insert(clas);
            return Mapper.Map<ClassDto>(clas);
        }

        public ClassDto Update(ClassDto classDto, string fileName)
        {
            classDto.Icon = fileName;
            var clas = Mapper.Map<Class>(classDto);
            this.classRepository.Update(clas);
            return Mapper.Map<ClassDto>(clas);
        }

        public void Delete(int? id)
        {
            var clas = this.classRepository.GetAll().FirstOrDefault(s => s.Id == id);
            this.classRepository.Delete(clas);
        }
    }
}