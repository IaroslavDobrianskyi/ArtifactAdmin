// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PredispositionService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the PredispositionService interface.
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

    public class PredispositionService : IPredispositionService
    {
        private readonly IRepository<Predisposition> predispositionRepository;

        public PredispositionService(IRepository<Predisposition> predispositionRepository)
        {
            this.predispositionRepository = predispositionRepository;
        }

        public IEnumerable<PredispositionDto> GetAll()
        {
            return Mapper.Map<List<PredispositionDto>>(this.predispositionRepository.GetAll());
        }

        public PredispositionDto GetById(int? id)
        {
            return Mapper.Map<PredispositionDto>(this.predispositionRepository.GetAll().FirstOrDefault(s => s.Id == id));
        }

        public PredispositionDto GetByPosition(int position)
        {
            return Mapper.Map<PredispositionDto>(this.predispositionRepository.GetAllNoTracking().FirstOrDefault(s => s.Position == position));
        }

        public PredispositionDto GetMaxByPosition(int position)
        {
            return Mapper.Map<PredispositionDto>(this.predispositionRepository.GetAllNoTracking()
                                                     .Where(s => s.Position < position)
                                                     .OrderByDescending(s => s.Position)
                                                     .FirstOrDefault());
        }

        public PredispositionDto GetMinByPosition(int position)
        {
            return Mapper.Map<PredispositionDto>(this.predispositionRepository.GetAllNoTracking()
                                                     .Where(s => s.Position > position)
                                                     .OrderBy(s => s.Position)
                                                     .FirstOrDefault());
        }

        public PredispositionDto Create(PredispositionDto predispositionDto)
        {
            var predisposition = Mapper.Map<Predisposition>(predispositionDto);
            this.predispositionRepository.Insert(predisposition);
            return Mapper.Map<PredispositionDto>(predisposition);
        }

        public PredispositionDto Update(PredispositionDto predispositionDto)
        {
            var predisposition = Mapper.Map<Predisposition>(predispositionDto);
            this.predispositionRepository.Update(predisposition);
            return Mapper.Map<PredispositionDto>(predisposition);
        }

        public void Delete(int id)
        {
            var predisposition = this.predispositionRepository.GetAll()
                                     .FirstOrDefault(s => s.Id == id);
            this.predispositionRepository.Delete(predisposition);
        }
    }
}