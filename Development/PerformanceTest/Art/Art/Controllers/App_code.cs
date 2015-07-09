using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Art.Models;
using System.Data.Entity;
//using log4net;
//using log4net.Config;

namespace Art
{
    public class App_code
    {
        //public static readonly ILog log = LogManager.GetLogger(typeof(App_code));
        
        public void Run(int c, int kStep, int kAct)
        {
            DateTime timeNow = DateTime.Now;
            //log4net.Config.XmlConfigurator.Configure();
            // c- threads count
            object[][] par = new object[c][];

            for (int i = 0; i < c; i++) 
            {
                par[i] = new object[4]{i+1,kStep,kAct, timeNow};
                PutFlow(par[i]);
            }

            
            //for (int i=0;i<c;i++)
            //{
                //par1[0] = 1;
                ////log.Info("1 par1 " + par1[0].ToString());
                //Thread thread = new Thread(PutFlow);
                //thread.Start(par[i]);
                //par2[0] = 2;
                ////log.Info("2 par2 " + par2[0].ToString());
                //Thread thread2 = new Thread(PutFlow);
                //thread2.Start(par2);

            //}
        }

        private void PutFlow(object obj)
        {
            object[] p =(object[]) obj;
//log.Info("Ідентифікатор  :"+ Thread.CurrentThread.ManagedThreadId.ToString()+" p0 "+p[0].ToString());
           // p[0] - user ID
           // p[1] - steps count
           // p[2] - actions count
            int parUser = (int)p[0];
            int kStep = (int)p[1];
            int kAct = (int)p[2];
            //DateTime t1 = (DateTime)p[3];
            DateTime t1 = DateTime.Now;
            DateTime t2 = DateTime.Now;
            //int fIdStep = 1;
            //int fIdAct = 101;
            //int fIdFlow = 1001;
            //int ActFlow;
            using (var db = new ArtEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        int i = 0;
                        Step[] StepNext = new Step[kStep];
                        ActFlow[] FixFlow = new ActFlow[kStep - 1];
                        StepNext[0] = db.Steps.Add(new Step { idUser = parUser });
                        Art.Models.Action[] NextAct = new Art.Models.Action[kAct];
                        for (int k = 1; k < kStep; k++)
                        {
                            
                            for (i = 0; i < kAct; i++)
                            {
                               NextAct[i] = db.Actions.Add(new Art.Models.Action { idUser = parUser, Step = StepNext[k-1] });
                            }

                            StepNext[k] = db.Steps.Add(new Step {idUser = parUser });
                            FixFlow[k-1] = db.ActFlows.Add(new ActFlow { idUser = parUser, Step = StepNext[k], Action = NextAct[i-kAct] });
                            db.SaveChanges();
                            StepNext[k-1].ActFlow = FixFlow[k-1];
                            //db.SaveChanges();
                        }
                        
                        //log.Info("Ідентифікатор  :" + Thread.CurrentThread.ManagedThreadId.ToString() + " parUser " + parUser.ToString());
                        db.SaveChanges();
                        transaction.Commit();
                        

                    }
                    catch
                    {
                        //log.Error(error.Message);
                        transaction.Rollback();
                    }
                    t2 = DateTime.Now;
                    Statistic NextStat = db.Statistics.Add(new Statistic { idUser = parUser, kStep = kStep, kAct = kAct, time = Convert.ToInt32((t2 - t1).TotalMilliseconds), nStep = 1, nAct = 101 });
                    db.SaveChanges();
                }

            }
        }
       
    }
}
