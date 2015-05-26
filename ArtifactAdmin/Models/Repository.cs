// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the Repository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ArtifactAdmin.DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly artEntities artEntities;
        private readonly DbSet<T> dataSet;

        public Repository(artEntities artEntities)
        {
            this.artEntities = artEntities;
            this.dataSet = artEntities.GetPropertyByType<T>();
        }

        public IQueryable<T> GetAll()
        {
            return dataSet;
        }

        public void Insert(T entity)
        {
            dataSet.Add(entity);
            this.artEntities.SaveChanges();
        }

        public void InsertDependent(T entity, string[] obj)
        {
            switch (entity.GetType().BaseType.Name)
            {
                case "StepTemplate":
                    var st = artEntities.StepTemplates.Add(entity as StepTemplate);
                    if (obj != null)
                    {
                        int objLen = obj.Length;
                        int fidStepObj = 0;
                        for (int i = 0; i < objLen; i++)
                        {
                            fidStepObj = Convert.ToInt32(obj[i].Substring(0, obj[i].IndexOf('.')));
                            artEntities.StepObjectStepTemplates.Add(new StepObjectStepTemplate
                                                                    {
                                                                        StepObject = fidStepObj,
                                                                        StepTemplate1 = st
                                                                    });
                        }
                    }

                    artEntities.SaveChanges();
                    break;
                default:
                    break;
            }
        }

        public void Update(T entity)
        {
            artEntities.Entry(entity).State = EntityState.Modified;
            artEntities.SaveChanges();
        }

        public void UpdateDependent(T entity, string[] obj)
        {
            switch (entity.ToString())
            {
                case "ArtifactAdmin.DAL.Models.StepTemplate":
                    var st = entity as StepTemplate;
                    artEntities.Entry(entity).State = EntityState.Modified;
                    var forDel = artEntities.StepObjectStepTemplates.Where(p => p.StepTemplate == st.id);
                    foreach (var type in forDel)
                    {
                        artEntities.StepObjectStepTemplates.Remove(type);
                    }

                    if (obj != null)
                    {
                        int objLen = obj.Length;
                        int fidStepObj = 0;
                        for (int i = 0; i < objLen; i++)
                        {
                            fidStepObj = Convert.ToInt32(obj[i].Substring(0, obj[i].IndexOf('.')));
                            artEntities.StepObjectStepTemplates.Add(new StepObjectStepTemplate
                            {
                                StepObject = fidStepObj,
                                StepTemplate1 = st
                            });
                        }   
                    }

                    artEntities.SaveChanges();
                    break;
                default:
                    break;
            }
        }

        public void Delete(T entity)
        {
            switch(entity.GetType().BaseType.Name)
            {
                case "StepTemplate":
                    var st = entity as StepTemplate;
                    var forDel = artEntities.StepObjectStepTemplates.Where(p => p.StepTemplate == st.id);
                    foreach (var type in forDel)
                    {
                        artEntities.StepObjectStepTemplates.Remove(type);
                    }
                    break;
                default:
                    break;
            }
            artEntities.Entry(entity)
                               .State = EntityState.Deleted;
            artEntities.SaveChanges();
        }

        public void SaveChanges()
        {
            artEntities.SaveChanges();
        }
    }
}