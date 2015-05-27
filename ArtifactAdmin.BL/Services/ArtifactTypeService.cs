// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArtifactTypeService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the ArtifactTypeService type.
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

    public class ArtifactTypeService : IArtifactTypeService
    {
        private readonly IRepository<ArtifactType> artifactTypeRepository;

        public ArtifactTypeService(IRepository<ArtifactType> artifactTypeRepository)
        {
            this.artifactTypeRepository = artifactTypeRepository;
        }

        public IEnumerable<ArtifactTypeDto> GetAll()
        {
            var artifactType = this.artifactTypeRepository.GetAll();
            return Mapper.Map<List<ArtifactTypeDto>>(this.artifactTypeRepository.GetAll());
        }

        public ArtifactTypeDto GetById(int? id)
        {
            var artifactType = this.artifactTypeRepository.GetAll()
                                   .FirstOrDefault(s => s.id == id);
            return Mapper.Map<ArtifactTypeDto>(this.artifactTypeRepository.GetAll().FirstOrDefault(s => s.id == id));
        }

        public ArtifactTypeDto Create(ArtifactTypeDto artifactTypeDto, HttpPostedFileBase icon)
        {
            var fileName = Path.GetFileName(icon.FileName);
            fileName = Guid.NewGuid()
                           .ToString() + '_' + fileName;
            artifactTypeDto.Icon = fileName;
            var artifactType = Mapper.Map<ArtifactType>(artifactTypeDto);
            this.artifactTypeRepository.Insert(artifactType);
            return Mapper.Map<ArtifactTypeDto>(artifactType);
        }

        public void SaveIcon(ArtifactTypeDto artifactTypeDto, HttpPostedFileBase icon)
        {
            var fileName = artifactTypeDto.Icon;
            string pathToIcon = App_Start.ImagePath.ImPath;
            var path = Path.Combine(HttpContext.Current.Server.MapPath(pathToIcon + "ArtifactTypes"), fileName);
            icon.SaveAs(path);
        }

        public ArtifactTypeDto Update(ArtifactTypeDto artifactTypeDto)
        {
            var artifactType = Mapper.Map<ArtifactType>(artifactTypeDto);
            this.artifactTypeRepository.Update(artifactType);
            return Mapper.Map<ArtifactTypeDto>(artifactType);
        }

        public void Delete(int? id)
        {
            var artifactType = this.artifactTypeRepository.GetAll()
                                   .FirstOrDefault(s => s.id == id);
            string fileName = artifactType.Icon;
            string pathToIcon = App_Start.ImagePath.ImPath;
            var path = Path.Combine(HttpContext.Current.Server.MapPath(pathToIcon + "ArtifactTypes"), fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }

            this.artifactTypeRepository.Delete(artifactType);
        }
    }
}