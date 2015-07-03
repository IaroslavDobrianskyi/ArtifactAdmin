// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionDescriptionService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ActionDescriptionService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO;

    public class ActionDescriptionService : IActionDescriptionService
    {
        private readonly IRepository<ActionDescription> actionDescriptionRepository;
        private readonly IRepository<MapZone> mapZoneRepository;
        private readonly IRepository<ActionTemplate> actionTemplateRepository;

        public ActionDescriptionService(IRepository<ActionDescription> actionDescriptionRepository,
            IRepository<MapZone> mapZoneRepository,
            IRepository<ActionTemplate> actionTemplateRepository) 
        {
            this.actionDescriptionRepository = actionDescriptionRepository;
            this.mapZoneRepository = mapZoneRepository;
            this.actionTemplateRepository = actionTemplateRepository;
        }

        public IEnumerable<ActionDescriptionDto> GetAll()
        {
            return Mapper.Map<List<ActionDescriptionDto>>(this.actionDescriptionRepository.GetAll().
                Include(s => s.ActionTemplate1).Include(s => s.MapZone1)); 
        }

        public ViewActionDescriptionDto GetViewById(int? id) 
        {
            var viewActionDescriptionDto = new ViewActionDescriptionDto();
            viewActionDescriptionDto.MapZoneDto = Mapper.Map<List<MapZoneDto>>(this.mapZoneRepository.GetAll());
            viewActionDescriptionDto.ActionTemplateDto = Mapper.Map<List<ActionTemplateDto>>(this.actionTemplateRepository.GetAll());
            if (id != null)
            {
                viewActionDescriptionDto.ActionDescriptionDto = Mapper.Map<ActionDescriptionDto>(this.actionDescriptionRepository.GetAll().
                    FirstOrDefault(s => s.id == id));
            }
            
            return viewActionDescriptionDto;
        }

        public ActionDescriptionDto GetById(int? id)
        {
            return Mapper.Map<ActionDescriptionDto>(this.actionDescriptionRepository.GetAll().
                Include(s => s.ActionTemplate1).Include(s => s.MapZone1).FirstOrDefault(s=>s.id==id));
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
            var actionDescription=this.actionDescriptionRepository.GetAll().FirstOrDefault(s=>s.id==id);
            this.actionDescriptionRepository.Delete(actionDescription);
        }
    }
}