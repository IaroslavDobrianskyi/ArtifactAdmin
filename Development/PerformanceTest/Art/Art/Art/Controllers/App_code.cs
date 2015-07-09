using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Art.Models;
using log4net;
using log4net.Config;

namespace Art
{
    class App_code
    {
        //public static readonly ILog log = LogManager.GetLogger(typeof(App_code));
        
        public void Run(int c, int kStep, int kAct)
        {
            //log4net.Config.XmlConfigurator.Configure();
            // c- threads count
            int[] par1 = new int[3];
            par1[1] = kStep;
            par1[2] = kAct;
            int[] par2 = new int[3];
            par2[1] = kStep;
            par2[2] = kAct;
            //for (int i=1;i<=c;i++)
            //{
                par1[0] = 1;
                //log.Info("1 par1 " + par1[0].ToString());
                Thread thread1 = new Thread(PutFlow);
                thread1.Start(par1);
                par2[0] = 2;
                //log.Info("2 par2 " + par2[0].ToString());
                Thread thread2 = new Thread(PutFlow);
                thread2.Start(par2);
                
            //}
        }

        private void PutFlow(object obj)
        {
            int[] p =(int[]) obj;
//log.Info("Ідентифікатор  :"+ Thread.CurrentThread.ManagedThreadId.ToString()+" p0 "+p[0].ToString());
           // p[0] - user ID
           // p[1] - steps count
           // p[2] - actions count
            int parUser = p[0];
            int kStep = p[1];
            int kAct = p[2];
            DateTime t1 = DateTime.Now;
            DateTime t2 = DateTime.Now;
            int fIdStep = 1;
            int fIdAct = 101;
            int fIdFlow = 1001;
            int ActFlow;

            using (artEntities db = new artEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Step StepNext = db.Steps.Add(new Step { id = fIdStep, idUser = parUser });
                        for (int k = 1; k <= kStep; k++)
                        {
                            ActFlow = fIdAct;
                            for (int i = 1; i <= kAct; i++)
                            {
                                Art.Models.Action NextAct = db.Actions.Add(new Art.Models.Action { id = fIdAct, idUser = parUser, idStep = fIdStep });
                                fIdAct++;
                            }

                            Step StepNext1 = db.Steps.Add(new Step { id = fIdStep + 1, idUser = parUser });
                            ActFlow FixFlow = db.ActFlows.Add(new ActFlow { id = fIdFlow, idUser = parUser, idStep = fIdStep + 1, idAction = ActFlow });
                            db.SaveChanges();
                            StepNext = db.Steps.Where(s => s.id == fIdStep & s.idUser == parUser).First();
                            StepNext.idActFlow = fIdFlow;
                            db.SaveChanges();
                            fIdStep++;
                            fIdFlow++;
                        }
                        t2 = DateTime.Now;

                        Statistic NextStat = db.Statistics.Add(new Statistic { idUser = parUser, kStep = kStep, kAct = kAct, time = (t2 - t1).Milliseconds, nStep = 1, nAct = 101 });
                        //log.Info("Ідентифікатор  :" + Thread.CurrentThread.ManagedThreadId.ToString() + " parUser " + parUser.ToString());
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception error)
                    {
                        //log.Error(error.Message);
                        transaction.Rollback();
                    }
                }

            }
        }
       
    }
}
