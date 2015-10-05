// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BonusService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the BonusService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;

    public class BonusService : IBonusService
    {
        private readonly IRepository<Bonu> bonuRepository;

        public BonusService(IRepository<Bonu> bonuRepository)
        {
            this.bonuRepository = bonuRepository;
        }

        public IEnumerable<BonusDto> GetAll()
        {
            return Mapper.Map<List<BonusDto>>(this.bonuRepository.GetAll());
        }

        public BonusDto GetById(int? id)
        {
            return Mapper.Map<BonusDto>(this.bonuRepository.GetAll()
                                            .FirstOrDefault(s => s.Id == id));
        }

        public BonusDto Create(BonusDto bonusDto)
        {
            var bonus = Mapper.Map<Bonu>(bonusDto);
            this.bonuRepository.Insert(bonus);
            return Mapper.Map<BonusDto>(bonus);
        }

        public BonusDto Update(BonusDto bonusDto)
        {
            var bonus = Mapper.Map<Bonu>(bonusDto);
            this.bonuRepository.Update(bonus);
            return Mapper.Map<BonusDto>(bonus);
        }

        public void Delete(int id)
        {
            var bonus = this.bonuRepository.GetAll()
                            .FirstOrDefault(s => s.Id == id);
            this.bonuRepository.Delete(bonus);
        }
    }
}