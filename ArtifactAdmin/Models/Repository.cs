// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="Artifact">
//   All rights reserved
// </copyright>
// <summary>
//   Defines the Repository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Linq;

namespace ArtifactAdmin.DAL.Models
{
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

        public IQueryable<T> GetAllNoTracking()
        {
            return dataSet.AsNoTracking();
        }

        public void Insert(T entity)
        {
            dataSet.Add(entity);
            this.artEntities.SaveChanges();
        }

        public void InsertWithoutSave(T entity) 
        {
            dataSet.Add(entity);
        }

        public void Update(T entity)
        {
            artEntities.Entry(entity).State = EntityState.Modified;
            artEntities.SaveChanges();
        }

        public void UpdateWithoutSave(T entity) 
        {
            artEntities.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            artEntities.Entry(entity)
                               .State = EntityState.Deleted;
            artEntities.SaveChanges();
        }

        public void DeleteWithOutSave(T entity)
        {
            artEntities.Entry(entity)
                              .State = EntityState.Deleted;
        }

        public void SaveChanges()
        {
            artEntities.SaveChanges();
        }

        public int QuestStarter(int id)
        {
            var starter = Convert.ToInt32(this.artEntities.QuestStarter(id).FirstOrDefault());
            return starter;
        }
    }
}