// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionDescriptionService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionDescriptionService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.DAL.Models;
using AutoMapper;

namespace ArtifactAdmin.BL.Services
{
    public class ActionDescriptionService : IActionDescriptionService
    {
        private readonly IRepository<ActionDescription> actionDescriptionRepository;
        private readonly IRepository<MapZone> mapZoneRepository;
        private readonly IRepository<ActionTemplate> actionTemplateRepository;
        private readonly IRepository<Race> raceRepository;
        private readonly IRepository<Class> classRepository; 

        public ActionDescriptionService(IRepository<ActionDescription> actionDescriptionRepository,
            IRepository<MapZone> mapZoneRepository,
            IRepository<ActionTemplate> actionTemplateRepository,
            IRepository<Race> raceRepository,
            IRepository<Class> classRepository) 
        {
            this.actionDescriptionRepository = actionDescriptionRepository;
            this.mapZoneRepository = mapZoneRepository;
            this.actionTemplateRepository = actionTemplateRepository;
            this.raceRepository = raceRepository;
            this.classRepository = classRepository;
        }

        public IEnumerable<ActionDescriptionDto> GetAll()
        {
            return Mapper.Map<List<ActionDescriptionDto>>(this.actionDescriptionRepository.GetAll().Include(s => s.ActionTemplate1).Include(s => s.MapZone1)
                .Include(s => s.Race1).Include(s => s.Class1)); 
        }

        public ViewActionDescriptionDto GetViewById(int? id) 
        {
            var viewActionDescriptionDto = new ViewActionDescriptionDto();
            viewActionDescriptionDto.MapZoneDto = Mapper.Map<List<MapZoneDto>>(this.mapZoneRepository.GetAll());
            viewActionDescriptionDto.ActionTemplateDto = Mapper.Map<List<ActionTemplateDto>>(this.actionTemplateRepository.GetAll());
            viewActionDescriptionDto.RaceDto = Mapper.Map<List<RaceDto>>(this.raceRepository.GetAll());
            viewActionDescriptionDto.ClassDto = Mapper.Map<List<ClassDto>>(this.classRepository.GetAll());
            if (id != null)
            {
                viewActionDescriptionDto.ActionDescriptionDto = Mapper.Map<ActionDescriptionDto>(this.actionDescriptionRepository.GetAll().FirstOrDefault(s => s.Id == id));
                viewActionDescriptionDto.ActionName =
                viewActionDescriptionDto.ActionDescriptionDto.ActionTemplate.ToString();
                viewActionDescriptionDto.NameZone = viewActionDescriptionDto.ActionDescriptionDto.MapZone.ToString();
                viewActionDescriptionDto.NameRace = viewActionDescriptionDto.ActionDescriptionDto.Race.ToString();
                viewActionDescriptionDto.NameClass = viewActionDescriptionDto.ActionDescriptionDto.Class.ToString();
            }

            return viewActionDescriptionDto;
        }

        public ActionDescriptionDto GetById(int? id)
        {
            return Mapper.Map<ActionDescriptionDto>(this.actionDescriptionRepository.GetAll()
                .Include(s => s.ActionTemplate1).Include(s => s.MapZone1).Include(s => s.Race1).Include(s => s.Class1).FirstOrDefault(s => s.Id == id));
        }

        public ActionDescriptionDto Create(ActionDescriptionDto actionDescriptionDto)
        {
            var actionDescription = Mapper.Map<ActionDescription>(actionDescriptionDto);
            this.actionDescriptionRepository.Insert(actionDescription);
            return Mapper.Map<ActionDescriptionDto>(actionDescription);
        }

        public ActionDescriptionDto Update(ActionDescriptionDto actionDescriptionDto)
        {
            var actionDescription = Mapper.Map<ActionDescription>(actionDescriptionDto);
            this.actionDescriptionRepository.Update(actionDescription);
            return Mapper.Map<ActionDescriptionDto>(actionDescription);
        }

        public void Delete(int? id)
        {
            var actionDescription = this.actionDescriptionRepository.GetAll().FirstOrDefault(s => s.Id == id);
            this.actionDescriptionRepository.Delete(actionDescription);
        }
    }
}