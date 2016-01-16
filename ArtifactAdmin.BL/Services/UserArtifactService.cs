using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtifactAdmin.BL.Services
{
    using ArtifactAdmin.BL.Interfaces;
    using ArtifactAdmin.DAL.Models;

    public class UserArtifactService : IUserArtifactService
    {
        private IRepository<UserArtifact> userArtifactRepository;

        public UserArtifactService(IRepository<UserArtifact> userArtifactRepository)
        {
            this.userArtifactRepository = userArtifactRepository;
        }

        public int GetUserArtifactPredictionRadius(int carrierId)
        {
            var uar = this.userArtifactRepository.GetAll().Where(u => u.Carrier == carrierId).FirstOrDefault();
            return uar.PredictionRadius;
        }
    }
}