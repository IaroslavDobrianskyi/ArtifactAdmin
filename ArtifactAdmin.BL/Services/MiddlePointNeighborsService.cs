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
    public class MiddlePointNeighborsService : IMiddlePointNeighborsService
    {
        private readonly IRepository<MiddlePointNeighbor> middlePointNeighborRepository;

        public MiddlePointNeighborsService(IRepository<MiddlePointNeighbor> middlePointNeighborRepository)
        {
            this.middlePointNeighborRepository = middlePointNeighborRepository;
        }

        public List<MiddlePointNeighborDto> GetMiddlePointNeighborsByDimentionRadius(int dimentionRadiusId)
        {
            return Mapper.Map<List<MiddlePointNeighborDto>>(
                this.middlePointNeighborRepository.GetAll().Where(n => n.DimensionRadius == dimentionRadiusId));

        }
    }
}