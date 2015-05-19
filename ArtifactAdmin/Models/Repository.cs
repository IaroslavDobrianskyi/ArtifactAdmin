﻿// --------------------------------------------------------------------------------------------------------------------
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
            artEntities.SaveChanges();
        }

        public void Update(T entity)
        {
            artEntities.Entry(entity).State = EntityState.Modified;
            artEntities.SaveChanges();
        }

        public void Delete(T entity)
        {
            artEntities.Entry(entity).State = EntityState.Deleted;
            artEntities.SaveChanges();
        }

        public void SaveChanges()
        {
            artEntities.SaveChanges();
        }
    }
}