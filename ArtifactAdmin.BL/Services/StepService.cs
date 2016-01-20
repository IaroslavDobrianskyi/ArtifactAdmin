// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StepService.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the StepServicetype.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArtifactAdmin.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Web.UI.WebControls;

    using ArtifactAdmin.BL.ModelsDTO;

    using AutoMapper;
    using DAL.Models;
    using Interfaces;
    using ModelsDTO.FlowItems;

    public class StepService : IStepService
    {
        
        private readonly IRepository<StepTemplate> stepTemplateRepository;
        
        private readonly IRepository<Step> stepRepository;
        private readonly IRepository<Carrier> carrierRepository;

        public StepService(
            IRepository<StepTemplate> stepTemplateRepository,
            IRepository<Step> stepRepository,
            IRepository<Carrier> carrierRepository)
        {
            this.stepTemplateRepository = stepTemplateRepository;
            this.stepRepository = stepRepository;
            this.carrierRepository = carrierRepository;
            
        }

        public StepDto GetById(int? id)
        {
            return Mapper.Map<StepDto>(this.stepRepository.GetAll()
                                                 .FirstOrDefault(s => s.Id == id));
        }

        public StepDto Create(StepDto stepDto, string fileName)
        {
            stepDto.Icon = fileName;
            var step = Mapper.Map<Step>(stepDto);
            this.stepRepository.Insert(step);
            return Mapper.Map<StepDto>(step);
        }

        public StepDto Update(StepDto stepDto, string fileName)
        {
            stepDto.Icon = fileName;
            var step = Mapper.Map<Step>(stepDto);
            this.stepRepository.Update(step);
            return Mapper.Map<StepDto>(step);
        }

        public StepDto RetrieveLastStepFromDb(int carrierId)
        {
            var step = stepRepository.GetAll()
                    .Where(
                        s =>
                        s.UserArtifact1.CarrierUserArtifacts.Count(x => x.Carrier == carrierId) > 0
                        && s.ActiveActionInFlow == null)
                    .FirstOrDefault();
            if (step == null)
            {
                throw new Exception("There is no available last step");
            }

            return Mapper.Map<StepDto>(step);
        }

        public List<StepDto> RetrieveSteps(int carrierId)
        {
            throw new NotImplementedException();
        }

        public StepDto RetrieveCurrentStepFromDb(int carrierId)
        {
            Step step = this.carrierRepository.GetAll().Where(x => x.Id == carrierId).Select(x => x.Step).FirstOrDefault();

            if (step == null)
            {
                throw new Exception("There is no available last step");
            }
            
            return Mapper.Map<StepDto>(step);
        }

        public StepDto GenerateStep(StepCreationInfo stepInfo)
        {
            var template = this.stepTemplateRepository.GetAll().Where(st => st.Id == stepInfo.TemplateId).FirstOrDefault();

            var step = new Step()
                           {
                               Desire = template.Desire,
                               Duration = 1, // TODO: як визначити тривалість кроку?
                               Icon = string.Empty, // TODO: де взяти іконку?
                               IsKey = stepInfo.IsKey,
                               Name = template.Name,
                               Text = template.StepText,
                               XCoordinate = stepInfo.Coordinates.X,
                               YCoordinate = stepInfo.Coordinates.Y
                           };
            this.stepRepository.Insert(step);       

            return Mapper.Map<StepDto>(step);
        }

        public void Delete(int? id)
        {
            var step = this.stepRepository.GetAll().FirstOrDefault(s => s.Id == id);
            this.stepRepository.Delete(step);
        }

        /// <inheritdoc/>
        public StepDto GetNextStep(StepDto currentStep)
        {
            StepDto retVal = null;
            if (currentStep.ActiveActionInFlow.HasValue)
            {
                var nextStep = this.stepRepository.GetAll().Where(s => s.Id == currentStep.Id).Select(s => s.ActiveActionInFlow1.Step1).FirstOrDefault();
                retVal = Mapper.Map<StepDto>(nextStep);
            }

            return retVal;
        }
    }
}