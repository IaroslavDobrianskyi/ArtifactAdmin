using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.ModelsDTO;
using ArtifactAdmin.BL.Utils.GeneratingMiddlePoints;
using ArtifactAdmin.DAL.Models;
using AutoMapper;

namespace ArtifactAdmin.BL.Services
{
    public class DimentionRadiusService : IDimentionRadiusService
    {
        private readonly IRepository<DimentionRadiu> dimentionRadiusRepository;
        private readonly IRepository<MiddlePoint> middlePointRepository;
        private readonly IRepository<MiddlePointNeighbor> middlePointNeighborRepository;

        public DimentionRadiusService(IRepository<DimentionRadiu> dimentionRadiusRepository, IRepository<MiddlePoint> middlePointRepository, IRepository<MiddlePointNeighbor> middlePointNeighborRepository)
        {
            this.dimentionRadiusRepository = dimentionRadiusRepository;
            this.middlePointRepository = middlePointRepository;
            this.middlePointNeighborRepository = middlePointNeighborRepository;
        }

        public IEnumerable<DimentionRadiuDto> GetAll()
        {
            return Mapper.Map<List<DimentionRadiuDto>>(this.dimentionRadiusRepository.GetAll());
        }

        public void Create(ModelsDTO.DimentionRadiuDto dimentionRadiusDto)
        {
            var dimentionRadius = Mapper.Map<DimentionRadiu>(dimentionRadiusDto);
            this.dimentionRadiusRepository.Insert(dimentionRadius);
            var allMiddlePoints =
                middlePointRepository.GetAll()
                                     .Where(m => m.MapInfoDimension == dimentionRadiusDto.MapInfoDimension)
                                     .ToList();


            var allMiddlePointsDto = Mapper.Map<List<MiddlePointDto>>(allMiddlePoints);
            foreach (var middlePointDto in allMiddlePointsDto)
            {

                middlePointNeighborRepository.Insert(new MiddlePointNeighbor()
                    {
                        DimensionRadius = dimentionRadius.Id,
                        MiddlePoint = middlePointDto.Id,
                        NeighborCoordinates =
                            NeighborMiddlePointsGenerator.GetNeighbors(middlePointDto, allMiddlePointsDto, dimentionRadius.Radius)
                    });
            }
        }

        public DimentionRadiuDto GetById(int? id)
        {
            return Mapper.Map<DimentionRadiuDto>(this.dimentionRadiusRepository.GetAll().FirstOrDefault(s => s.Id == id));
        }
    }
}