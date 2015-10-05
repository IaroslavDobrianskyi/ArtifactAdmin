// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TalentService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the TalentService type.
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
    public class TalentService : ITalentService
    {
        private readonly IRepository<Talent> talentRepository;

        public TalentService(IRepository<Talent> talentRepository)
        {
            this.talentRepository = talentRepository;
        }

        public IEnumerable<TalentDto> GetAll()
        {
            return Mapper.Map<List<TalentDto>>(this.talentRepository.GetAll());
        }

        public TalentDto GetById(int? id)
        {
            return Mapper.Map<TalentDto>(this.talentRepository.GetAll()
                                             .FirstOrDefault(s => s.Id == id));
        }

        public TalentDto Create(TalentDto talentDto, string fileName)
        {
            talentDto.Icon = fileName;
            var talent = Mapper.Map<Talent>(talentDto);
            this.talentRepository.Insert(talent);
            return Mapper.Map<TalentDto>(talent);
        }

        public TalentDto Update(TalentDto talentDto, string fileName)
        {
            talentDto.Icon = fileName;
            var talent = Mapper.Map<Talent>(talentDto);
            this.talentRepository.Update(talent);
            return Mapper.Map<TalentDto>(talent);
        }

        public void Delete(int? id)
        {
            var talent = this.talentRepository.GetAll()
                             .FirstOrDefault(s => s.Id == id);
            this.talentRepository.Delete(talent);
        }
    }
}