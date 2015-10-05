using System.Collections.Generic;
using System.Linq;
using ArtifactAdmin.BL.Interfaces;
using ArtifactAdmin.BL.Utils.GeneratingMiddlePoints;
using ArtifactAdmin.DAL.Models;

namespace ArtifactAdmin.BL.Services
{
    public class MiddlePointNeighborsService : IMiddlePointNeighborsService
    {
        private readonly IRepository<MiddlePointNeighbor> middlePointNeighborRepository;

        public MiddlePointNeighborsService(IRepository<MiddlePointNeighbor> middlePointNeighborRepository)
        {
            this.middlePointNeighborRepository = middlePointNeighborRepository;
        }

        public Dictionary<SimplePoint, List<SimplePoint>> GetMiddlePointNeighborsByDimentionRadius(int dimentionRadiusId)
        {
            var retVal = new Dictionary<SimplePoint, List<SimplePoint>>();

            var middlePointNeighbors = this.middlePointNeighborRepository.GetAll().Where(n => n.DimensionRadius == dimentionRadiusId);
            foreach (var middlePointNeighbor in middlePointNeighbors)
            {
                retVal.Add(new SimplePoint()
                    {
                        X = middlePointNeighbor.MiddlePoint1.X,
                        Y = middlePointNeighbor.MiddlePoint1.Y
                    }, NeighborMiddlePointsGenerator.GetNeighbors(middlePointNeighbor.NeighborCoordinates));

            }

            return retVal;
        }
    }
}