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
                                             .FirstOrDefault(s => s.id == id));
        }

        public TalentDto Create(TalentDto talentDto, HttpPostedFileBase icon)
        {
            var fileName = Path.GetFileName(icon.FileName);
            fileName = Guid.NewGuid()
                           .ToString() + '_' + fileName;
            talentDto.Icon = fileName;
            var talent = Mapper.Map<Talent>(talentDto);
            this.talentRepository.Insert(talent);
            return Mapper.Map<TalentDto>(talent);
        }

        public void SaveIcon(TalentDto talentDto, HttpPostedFileBase icon)
        {
            var fileName = talentDto.Icon;
            var pathToIcon = App_Start.ImagePath.ImPath;
            var path = Path.Combine(HttpContext.Current.Server.MapPath(pathToIcon + "Talents"), fileName);
            icon.SaveAs(path);
        }

        public TalentDto Update(TalentDto talentDto)
        {
            var talent = Mapper.Map<Talent>(talentDto);
            this.talentRepository.Update(talent);
            return Mapper.Map<TalentDto>(talent);
        }

        public void Delete(int? id)
        {
            var talent = this.talentRepository.GetAll()
                             .FirstOrDefault(s => s.id == id);
            string fileName = talent.Icon;
            string pathToIcon = App_Start.ImagePath.ImPath;
            var path = Path.Combine(HttpContext.Current.Server.MapPath(pathToIcon + "Talent"), fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }

            this.talentRepository.Delete(talent);
        }
    }
}