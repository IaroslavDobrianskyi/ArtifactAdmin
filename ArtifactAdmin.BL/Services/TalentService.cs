// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TalentService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the TalentService type.
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