using System;
using System.Collections.Generic;
using System.Linq;
using ArtifactAdmin.BL.ModelsDTO.FlowItems;
using ArtifactAdmin.DAL.Models;
using Action = ArtifactAdmin.DAL.Models.Action;

namespace ArtifactAdmin.BL.Services
{
    public class FlowService
    {
        public FlowService()
        {
        }

        public void SaveFlow(int userId, LinkedList<FlowStep> stepsToSave)
        {
            using (artEntities db = new artEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        for (var node = stepsToSave.First; node != null; node = node.Next)
                        {

                            foreach (var action in node.Value.ActionsList)
                            {
                                var actionToBeSaved = new Action
                                                         {
                                                             //TODO fill all fields. Create converter method.
                                                             ActionChangeCost = action.ActionChangeCost,
                                                             ExperienceModifier = action.ExperienceModifier
                                                         };

                                db.Actions.Add(actionToBeSaved);
                                if (action.Id == node.Value.ActiveAction)
                                {
                                    node.Value.ActiveAction = actionToBeSaved.Id;
                                }
                            }

                            //TODO fill all fields. Create converter method.
                            Step stepToBeSaved = new Step { Duration = node.Value.Duration, Name = node.Value.Name, ActiveActionInFlow = node.Value.ActiveAction };
                            db.Steps.Add(stepToBeSaved);
                            db.SaveChanges();

                            if (stepsToSave.First != node)
                            {
                                var firstOrDefault = db.Actions.FirstOrDefault(el => el.Id == node.Previous.Value.ActiveAction);
                                if (firstOrDefault != null)
                                {
                                    firstOrDefault.Step = stepToBeSaved.Id;
                                }
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        //log.Error(error.Message);
                        transaction.Rollback();
                    }
                }
            }
        }

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
    }
}