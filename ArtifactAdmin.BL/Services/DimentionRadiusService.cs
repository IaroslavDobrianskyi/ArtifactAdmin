using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.DAL.Models;
using AutoMapper;

namespace ArtifactAdmin.BL.Services
{
    public class DimentionRadiusService : IDimentionRadiusService
    {
        private readonly IRepository<DimentionRadiu> dimentionRadiusRepository;

        public DimentionRadiusService(IRepository<DimentionRadiu> dimentionRadiusRepository)
        {
            this.dimentionRadiusRepository = dimentionRadiusRepository;
        }

        public IEnumerable<DimentionRadiuDto> GetAll()
        {
            return Mapper.Map<List<DimentionRadiuDto>>(this.dimentionRadiusRepository.GetAll());
        }

        public void Create(ModelsDTO.DimentionRadiuDto dimentionRadiusDto)
        {
            var dimentionRadius = Mapper.Map<DimentionRadiu>(dimentionRadiusDto);
            this.dimentionRadiusRepository.Insert(dimentionRadius);

            //var mapInfo = this.mapInfoRepository.GetAll().Where(d => d.Id == mapInfoDimension.MapInfo).FirstOrDefault();

            //var middlePoints = MapMiddlePointsGenerator.GetMiddlePoints(mapInfo.ImagePath, mapInfoDimension.Dimension);



            //foreach (var key in middlePoints.Keys)
            //{
            //    middlePointRepository.Insert(new MiddlePoint()
            //        {
            //            MapInfoDimension = mapInfoDimension.Id,
            //            X = key.X,
            //            Y = key.Y,
            //            RelatedCoordinates = middlePoints[key].Serialize()
            //        });
            //}
        }
    }
}