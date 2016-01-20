namespace ArtifactAdmin.BL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using System.Drawing;
    using System.Linq;

    using ArtifactAdmin.BL.ModelsDTO.FlowItems;
    using ArtifactAdmin.DAL.Models;

    using Interfaces;

    public class FlowService : IFlowService
    {
        private readonly IStepService stepService;
        private readonly IUserArtifactService userArtifactService;
        private readonly IDesireService desireService;
        private readonly IActionService actionService;
        private readonly IRepository<Step> stepRepository;
        private readonly IStepFinderService stepFinderService;

        public FlowService(
            IStepService stepService,
            IDesireService desireService,
            IActionService actionService,
            IUserArtifactService userArtifactService,
            IStepFinderService stepFinderService)
        {
            this.stepService = stepService;
            this.desireService = desireService;
            this.actionService = actionService;
            this.userArtifactService = userArtifactService;
            this.stepFinderService = stepFinderService;
        }

        //public void SaveFlow(int userId, LinkedList<FlowStep> stepsToSave)
        //{
        //    using (artEntities db = new artEntities())
        //    {
        //        using (var transaction = db.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                for (var node = stepsToSave.First; node != null; node = node.Next)
        //                {

        //                    foreach (var action in node.Value.ActionsList)
        //                    {
        //                        var actionToBeSaved = new Action
        //                                                 {
        //                                                     //TODO fill all fields. Create converter method.
        //                                                     ActionChangeCost = action.ActionChangeCost,
        //                                                     ExperienceModifier = action.ExperienceModifier
        //                                                 };

        //                        db.Actions.Add(actionToBeSaved);
        //                        if (action.Id == node.Value.ActiveAction)
        //                        {
        //                            node.Value.ActiveAction = actionToBeSaved.Id;
        //                        }
        //                    }

        //                    //TODO fill all fields. Create converter method.
        //                    Step stepToBeSaved = new Step { Duration = node.Value.Duration, Name = node.Value.Name, ActiveActionInFlow = node.Value.ActiveAction };
        //                    db.Steps.Add(stepToBeSaved);
        //                    db.SaveChanges();

        //                    if (stepsToSave.First != node)
        //                    {
        //                        var firstOrDefault = db.Actions.FirstOrDefault(el => el.Id == node.Previous.Value.ActiveAction);
        //                        if (firstOrDefault != null)
        //                        {
        //                            firstOrDefault.Step = stepToBeSaved.Id;
        //                        }
        //                    }
        //                }
        //            }
        //            catch (Exception error)
        //            {
        //                //log.Error(error.Message);
        //                transaction.Rollback();
        //            }
        //        }
        //    }
        //}

        //private void PutFlow(object obj)
        //{
        //    int[] p = (int[])obj;
        //    //log.Info("Ідентифікатор  :"+ Thread.CurrentThread.ManagedThreadId.ToString()+" p0 "+p[0].ToString());
        //    // p[0] - user ID
        //    // p[1] - steps count
        //    // p[2] - actions count
        //    int parUser = p[0];
        //    int kStep = p[1];
        //    int kAct = p[2];
        //    DateTime t1 = DateTime.Now;
        //    DateTime t2 = DateTime.Now;
        //    int fIdStep = 1;
        //    int fIdAct = 101;
        //    int fIdFlow = 1001;
        //    int ActFlow;

        //    using (artEntities db = new artEntities())
        //    {
        //        using (var transaction = db.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                Step StepNext = db.Steps.Add(new Step { id = fIdStep, idUser = parUser });
        //                for (int k = 1; k <= kStep; k++)
        //                {
        //                    ActFlow = fIdAct;
        //                    for (int i = 1; i <= kAct; i++)
        //                    {
        //                        Art.Models.Action NextAct = db.Actions.Add(new Art.Models.Action { id = fIdAct, idUser = parUser, idStep = fIdStep });
        //                        fIdAct++;
        //                    }

        //                    Step StepNext1 = db.Steps.Add(new Step { id = fIdStep + 1, idUser = parUser });
        //                    ActFlow FixFlow = db.ActFlows.Add(new ActFlow { id = fIdFlow, idUser = parUser, idStep = fIdStep + 1, idAction = ActFlow });
        //                    db.SaveChanges();
        //                    StepNext = db.Steps.Where(s => s.id == fIdStep & s.idUser == parUser).First();
        //                    StepNext.idActFlow = fIdFlow;
        //                    db.SaveChanges();
        //                    fIdStep++;
        //                    fIdFlow++;
        //                }
        //                t2 = DateTime.Now;

        //                Statistic NextStat = db.Statistics.Add(new Statistic { idUser = parUser, kStep = kStep, kAct = kAct, time = (t2 - t1).Milliseconds, nStep = 1, nAct = 101 });
        //                //log.Info("Ідентифікатор  :" + Thread.CurrentThread.ManagedThreadId.ToString() + " parUser " + parUser.ToString());
        //                db.SaveChanges();
        //                transaction.Commit();
        //            }
        //            catch (Exception error)
        //            {
        //                //log.Error(error.Message);
        //                transaction.Rollback();
        //            }
        //        }

        //    }
        //}

        public void GenerateFlow(int carrierId)
        {
            var lastStep = this.stepService.RetrieveLastStepFromDb(carrierId);
            var currentStep = this.stepService.RetrieveCurrentStepFromDb(carrierId);

            var predictionRadius = this.userArtifactService.GetUserArtifactPredictionRadius(carrierId);
            var stepsFromCurrentToLast = this.GetSteps(currentStep, lastStep);
            var existingFlowDuration = this.CalculateStepsDuration(stepsFromCurrentToLast);
                     
            // Тут треба порахувати чи радіус передбачення більший за кількість часу/кроків між останнім і поточним
            if (predictionRadius < existingFlowDuration)
            {
                return;
            } 

            var currentCarriesDesiresState = this.desireService.RetrieveListOfCurrentCarrierDesires(carrierId);
            var fromCurrentToLastActionResultCarriesDesires = this.actionService.RetrieveListOfActionResultDesires(stepsFromCurrentToLast);
            var desiresInTheFlowEnd = this.actionService.ApplyActionResultDesire(currentCarriesDesiresState, fromCurrentToLastActionResultCarriesDesires);
            var maxLastDesire = desiresInTheFlowEnd.OrderByDescending(desire => desire.Value).FirstOrDefault();

            var newKeyStepInfo = this.stepFinderService.GetNewKeyStepInfo(
                maxLastDesire,
                new Point()
                    {
                        X = lastStep.XCoordinate,
                        Y = lastStep.YCoordinate
                    });

            var intermediateStepsInfo = this.stepFinderService.GetIntermediateStepCoords(lastStep, newKeyStepInfo);
            intermediateStepsInfo.Add(newKeyStepInfo);
            foreach (var stepInfo in intermediateStepsInfo)
            {
                var step = this.stepService.GenerateStep(stepInfo); //Save to DB
                this.actionService.GenerateActions(step, stepInfo); //Saves to DB
                var activeActionResultDesire = this.actionService.GetActiveActionResultDesire(step);
                var desireList = this.actionService.ApplyActionResultDesire(desiresInTheFlowEnd, activeActionResultDesire);
                var maxDesire = desireList.OrderBy(x=>x.Value).FirstOrDefault();
                if (maxDesire.Id != maxLastDesire.Id)
                {
                    this.GenerateFlow(carrierId);
                    break;
                }
            }
        }

        private List<StepDto> GetSteps(StepDto startStep, StepDto endStep)
        {
            var retVal = new List<StepDto>();
            var currentStep = startStep;
            do
            {
                retVal.Add(currentStep);
                currentStep = this.stepService.GetNextStep(currentStep);
            }
            while (currentStep != null);
            return retVal;
        }

        private int CalculateStepsDuration(List<StepDto> steps)
        {
            var duration = 0;
            foreach (var stepDto in steps)
            {
                duration += stepDto.Duration;
            }

            return duration;
        }
        


        /*FlowService.GenerateFlow(CarrierId)
   GenerateFlow(carrierId)
   {
      if(lastStep - currentStep > CarrierService.GetUserArtifactPredictionRadius(carrierId))
        {
          return;
         } 
        
       var lastStep = StepService.RetrieveLastStepFromDB(carrierId);
       var currentStep = StepService.RetrieveCurrentStepFromDB(carrierId);
       var currentDesireList = DesireService.RetrieveListOfCurrentCarrierDesires(carrierId);
       var ListActionResults = ActionService.RetrieveListOfActionResults(CurrentStep, LastStep)
       var lastDesireList = ActionService.ApplyActionResultDesire(ListActionResults, currentDesireList)
       var maxLastDesire = lastDesireList.Max(Value);
        
       //Тут починається генерація нового флову
        
       var KeyStepCoords = StepFinderService.GetKeyStepCoords(maxLastDesire, lastStep.Coords);
       var IntermediateStepsCoords = StepFinderService.GetIntermediateStepCoords(lastStep, keyStep);
       IntermediateStepsCoords.Add(KeyStepCoords);   
       foreach(item in IntermediateStepsCoords)
       {
           var step = StepService.GenerateStep(item); //Save to DB
           var actionResult = ActionService.GenerateActionResult(step); //Saves to DB
           var desireList = ActionService.ApplyActionResultDesire(actionResult, lastDesireList);
           var maxDesire = desireList.Max(Value);
           if(maxDesire != maxLastDesire)
           {
               GenerateFlow(carrierId);
           }
       }
   }
     
    *
    ApplyActionResultDesire(ListActionResults, currentDesireList) 
    * {
    *  foreach (var actionResult in ListActionResults)
    *  {
    *      ActionService.ApplyActionResultDesire(actionResult, lastDesireList);
    *  }
    * }
    */
    }
}