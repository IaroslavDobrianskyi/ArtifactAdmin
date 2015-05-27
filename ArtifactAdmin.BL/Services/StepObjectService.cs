// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepObjectService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepObjectServicetype.
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

    public class StepObjectService : IStepObjectService
    {
        private readonly IRepository<StepObject> stepObjectRepository;

        public StepObjectService(IRepository<StepObject> stepObjectRepository)
        {
            this.stepObjectRepository = stepObjectRepository;
        }

        public IEnumerable<StepObjectDto> GetAll()
        {
            return Mapper.Map<List<StepObjectDto>>(this.stepObjectRepository.GetAll().Include(s => s.StepObjectType1));
        }

        public StepObjectDto GetById(int? id)
        {
            return Mapper.Map<StepObjectDto>(this.stepObjectRepository.GetAll()
                                                 .FirstOrDefault(s => s.id == id));
        }

        public StepObjectDto Create(StepObjectDto stepObjectDto, HttpPostedFileBase icon)
        {
            var fileName = Path.GetFileName(icon.FileName);
            fileName = Guid.NewGuid()
                           .ToString() + "_" + fileName;
            stepObjectDto.Icon = fileName;
            var stepObject = Mapper.Map<StepObject>(stepObjectDto);
            this.stepObjectRepository.Insert(stepObject);
            return Mapper.Map<StepObjectDto>(stepObject);
        }

        public void SaveIcon(StepObjectDto stepObjectDto, HttpPostedFileBase icon)
        {
            var fileName = stepObjectDto.Icon;
            var pathToIcon = App_Start.ImagePath.ImPath;
            var path = Path.Combine(HttpContext.Current.Server.MapPath(pathToIcon + "StepObjects"), fileName);
            icon.SaveAs(path);
        }

        public StepObjectDto Update(StepObjectDto stepObjectDto)
        {
            var stepObject = Mapper.Map<StepObject>(stepObjectDto);
            this.stepObjectRepository.Update(stepObject);
            return Mapper.Map<StepObjectDto>(stepObject);
        }

        public void Delete(int? id)
        {
            var stepObject = this.stepObjectRepository.GetAll().FirstOrDefault(s => s.id == id);
            string fileName = stepObject.Icon;
            string pathToIcon = App_Start.ImagePath.ImPath;
            var path = Path.Combine(HttpContext.Current.Server.MapPath(pathToIcon + "StepObjects"), fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }

            this.stepObjectRepository.Delete(stepObject);
        }
    }
}